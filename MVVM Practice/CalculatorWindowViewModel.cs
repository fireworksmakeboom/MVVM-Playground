using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Practice
{
    public class CalculatorWindowViewModel : BaseViewModel
    {
        public CalculatorWindowViewModel()
        {
            this.NumberCommand = new RelayCommand((value) =>
            {
                double val = double.Parse((string)value);
                this.CurrentValue = this.CurrentValue * 10.0 + val;
            });
            this.OperatorCommand = new RelayCommand((op) =>
            {
                string _op = (string)op;

                switch (operatorToExecute)
                {
                    case "+":
                        CurrentValue = lastValue + CurrentValue;
                        break;
                    case "-":
                        CurrentValue = lastValue - CurrentValue;
                        break;
                    case "*":
                        CurrentValue = lastValue * CurrentValue;
                        break;
                    case "/":
                        CurrentValue = lastValue / CurrentValue;
                        break;
                    default:
                        break;
                }

                if (_op == "=")
                {
                    this.operatorToExecute = null;
                    this.lastValue = CurrentValue;
                }
                else
                {
                    this.operatorToExecute = _op;
                    this.lastValue = CurrentValue;
                    CurrentValue = 0.0;
                }

            }); 
        }

        double currValue;
        public double CurrentValue
        {
            get { return currValue; }
            set
            {
                if (currValue != value)
                {
                    currValue = value;
                    this.OnPropertyChanged();
                }
            }
        }

        double lastValue;
        string operatorToExecute;

        public RelayCommand NumberCommand { get; set; }
        public RelayCommand OperatorCommand { get; set; }
    }
}
