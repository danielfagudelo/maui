using MauiApp1.MVVM.Models;
using PropertyChanged;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _model = new CalculatorModel();

        private string _displayValue;
        public string DisplayValue
        {
            get { return _displayValue; }
            set
            {
                _displayValue = value;
                OnPropertyChanged(nameof(DisplayValue));
            }
        }

        public ICommand NumberCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SubtractCommand { get; private set; }
        public ICommand MultiplyCommand { get; private set; }
        public ICommand DivideCommand { get; private set; }
        public ICommand EqualsCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }

        private string _currentNumber = string.Empty;
        private string _operation = string.Empty;

        public CalculatorViewModel()
        {
            NumberCommand = new Command<string>(NumberCommandExecute);
            AddCommand = new Command(AddCommandExecute);
            SubtractCommand = new Command(SubtractCommandExecute);
            MultiplyCommand = new Command(MultiplyCommandExecute);
            DivideCommand = new Command(DivideCommandExecute);
            EqualsCommand = new Command(EqualsCommandExecute);
            ClearCommand = new Command(ClearCommandExecute);
        }

        private void NumberCommandExecute(string number)
        {
            _currentNumber += number;
            DisplayValue = _currentNumber;
        }

        private void AddCommandExecute()
        {
            _operation = "+";
            _model.StoreNumber(double.Parse(_currentNumber));
            _currentNumber = string.Empty;
        }

        private void SubtractCommandExecute()
        {
            _operation = "-";
            _model.StoreNumber(double.Parse(_currentNumber));
            _currentNumber = string.Empty;
        }

        private void MultiplyCommandExecute()
        {
            _operation = "*";
            _model.StoreNumber(double.Parse(_currentNumber));
            _currentNumber = string.Empty;
        }

        private void DivideCommandExecute()
        {
            _operation = "/";
            _model.StoreNumber(double.Parse(_currentNumber));
            _currentNumber = string.Empty;
        }

        private void EqualsCommandExecute()
        {
            if (!string.IsNullOrEmpty(_operation) && !string.IsNullOrEmpty(_currentNumber))
            {
                double currentNumber = double.Parse(_currentNumber);
                double result;

                switch (_operation)
                {
                    case "+":
                        result = _model.Add(currentNumber);
                        break;
                    case "-":
                        result = _model.Subtract(currentNumber);
                        break;
                    case "*":
                        result = _model.Multiply(currentNumber);
                        break;
                    case "/":
                        result = _model.Divide(currentNumber);
                        break;
                    default:
                        return;
                }

                DisplayValue = result.ToString();
                _currentNumber = result.ToString();
                _operation = string.Empty;
            }
        }

        private void ClearCommandExecute()
        {
            _currentNumber = string.Empty;
            _operation = string.Empty;
            DisplayValue = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}