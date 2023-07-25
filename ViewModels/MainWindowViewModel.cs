using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace CalculatorDemo.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private double _firstNumber;
        [ObservableProperty]
        private double _secondNumber;
        [ObservableProperty]
        private double _result;
        [ObservableProperty]
        private string _operator = "";

        private bool _firstInput = true;

        [RelayCommand]
        private void NumberPressed(string number)
        {
            if (!int.TryParse(number, out int result))
                throw new ArgumentException($"Could not parse number to int ({number})", nameof(number));
            if (_firstInput)
                FirstNumber = result;
            else
                SecondNumber = result;
        }

        [RelayCommand]
        private void OperatorPressed(string op)
        {
            switch (op)
            {
                case "=":
                    ProcessResult();
                    return;
                case "+/-":
                    if (_firstInput)
                        FirstNumber *= -1;
                    else
                        SecondNumber *= -1;
                    return;
                case ".":
                    // Some logic/method/flag to let NumberPressed know that the next numbers will be decimals
                    return;
            }

            Operator = op;
            _firstInput = false;
        }

        [RelayCommand]
        private void Clear()
        {
            _firstInput = true;
            FirstNumber = 0;
            SecondNumber = 0;
            Result = 0;
            Operator = "";
        }

        private void ProcessResult()
        {
            switch (Operator)
            {
                case "+":
                    Result = FirstNumber + SecondNumber;
                    break;
                case "-":
                    Result = FirstNumber - SecondNumber;
                    break;
                case "x":
                    Result = FirstNumber * SecondNumber;
                    break;
                case "÷":
                    Result = FirstNumber / SecondNumber;
                    break;
                case "%":
                    Result = FirstNumber % SecondNumber;
                    break;
                case "":
                    Result = FirstNumber;
                    break; 
                default:
                    throw new ArgumentException($"Could not process result for {Operator}");
            }
            _firstInput = true;
        }
    }
}