using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Practice
{
    //Or DelegateCommand
    public class RelayCommand : ICommand
    {
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute) 
            => this.execute = execute;
        public RelayCommand(Predicate<object> canExecute, Action<object> execute) : this(execute) 
            => this.canExecute = canExecute;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => this.canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => this.execute?.Invoke(parameter);

        public void OnCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
