using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Practice
{
    class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand ClearCommand { get; set; }
        public MainWindowViewModel()
        {

            this.ClearCommand = new RelayCommand(
                (o) => !String.IsNullOrEmpty(Firstname) || !String.IsNullOrEmpty(Lastname),
                (o) => { this.Firstname = ""; this.Lastname = ""; }
            );

            Firstname = "Lutz";
            Lastname = "M";
        }

        private string firstname;
        public string Firstname 
        {
            get => firstname;
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    this.OnPropertyChanged();
                    this.OnPropertyChanged(nameof(FullName));
                    this.ClearCommand.OnCanExecuteChanged();
                }
            }
        }

        private string lastname;
        public string Lastname
        {
            get => lastname;
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    this.OnPropertyChanged();
                    this.OnPropertyChanged(nameof(FullName));
                    this.ClearCommand.OnCanExecuteChanged();
                }
            }
        }

        public string FullName => $"{Firstname} {Lastname}";
    }
}
