using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatServerSetings.ViewModel
{
    class LoginViewModel : Utilites.NotifyPropertyChanged
    {
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand AuthPassCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public LoginViewModel()
        {
            this.AuthPassCommand = new Utilites.Command(AuthPass);
            this.ExitCommand = new Utilites.Command(Utilites.UtilitesProgect.Exit);
        }

        public void AuthPass(object obj)
        {
            if (this.Password == Properties.Settings.Default.Password)
                MainViewModel.MainView.SetPage(new View.AllPage.ChangePathPage());
            else
                MessageBox.Show("Пароль введен неверно");
        }
    }
}
