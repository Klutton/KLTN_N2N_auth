using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Nyan_n2n.ViewModels
{
    public class AuthConViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ShowMessageCommand { get; set; }

        public AuthConViewModel()
        {
            //ShowMessageCommand = new RelayCommand(ShowMessage);
        }

        private void ShowMessage()
        {
            MessageBox.Show("Hello, World!");
        }

    }
}
