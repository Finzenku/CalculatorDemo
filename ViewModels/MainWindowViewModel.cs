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
        private bool _isDecimal;

        [RelayCommand]
        private void NumberPressed(string number)
        {
            if (!int.TryParse(number, out int result))
                throw new ArgumentException($"Could not parse number to int ({number})", nameof(number));

            if (_firstInput)
            {
                if (_isDecimal)
                {
                    // some code
                }
                else
                {
                if (FirstNumber >= 0)
                {
                    FirstNumber = FirstNumber * 10 + result;
                }
            else
                {
                    FirstNumber = FirstNumber * 10 - result;
        }
            }    
            }
            else
            {
                if (_isDecimal)
                {
                    // some code
                }
                else
                {
                if (SecondNumber >= 0)
                {
                    SecondNumber = SecondNumber * 10 + result;
                }
                else
                {
                    SecondNumber = SecondNumber * 10 - result;
                }
            }
        }
        }

        [RelayCommand]
        private void OperatorPressed(string op)
        {
            switch (op)
            {
                case "=":
                    ProcessResult();
                    break;
                case "+/-":
                    if (_firstInput)
                        FirstNumber *= -1;
                    else
                        SecondNumber *= -1;
                    break;
                case "%":
                    if (_firstInput)
                        FirstNumber *= 0.01;
                    else
                        SecondNumber *= 0.01;
                    break;
                case ".":
                    // Some logic/method/flag to let NumberPressed know that the next numbers will be decimals
                    _isDecimal = true;
                    break;
                default:
            Operator = op;
            _firstInput = false;
                    _isDecimal = false;
                    break; 

            }
        }

        [RelayCommand]
        private void Clear()
        {
            _firstInput = true;
            _isDecimal = false;
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