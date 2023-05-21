using System.ComponentModel;

namespace MauiApp1.MVVM.Models
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _currentNumber;
        private double _storedNumber;
        private string _currentOperation;

        public void StoreNumber(double number)
        {
            _storedNumber = number;
        }

        public double Add(double number)
        {
            _currentNumber = _storedNumber + number;
            _storedNumber = _currentNumber;
            return _currentNumber;
        }

        public double Subtract(double number)
        {
            _currentNumber = _storedNumber - number;
            _storedNumber = _currentNumber;
            return _currentNumber;
        }

        public double Multiply(double number)
        {
            _currentNumber = _storedNumber * number;
            _storedNumber = _currentNumber;
            return _currentNumber;
        }

        public double Divide(double number)
        {
            if (number != 0)
            {
                _currentNumber = _storedNumber / number;
                _storedNumber = _currentNumber;
            }
            return _currentNumber;
        }
    }
}
