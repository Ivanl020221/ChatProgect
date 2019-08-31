using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chat2._0.AllPage.Auth.ViewModel
{
    class AutorizatonViewModel : Core.NotifyPropertyChanged
    {
        private string _FontLock = "MS Outlook", _Login, _Password;

        //MS Outlook
        public string FontLock
        {
            get => _FontLock;
            set
            {
                _FontLock = value;
                OnPropertyChanged("FontLock");
            }
        }

        public static Entity.Employee CurrentUser { get; set; }

        public string Login
        {
            get => _Login;
            set
            {
                _Login = value;
                OnPropertyChanged("Login");
            }
        }
    public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }
        public ICommand VisiblePasswordCommand { get; set; }

        private bool IsLock = true;

        public AutorizatonViewModel()
        {
            VisiblePasswordCommand = new Core.Command(VisiblePassword);
        }

        private void VisiblePassword(object obj)
        {
            FontLock = !IsLock ? "MS Outlook" : "Arial";
            ReverseLock();
        }

        private void ReverseLock()
        {
            this.IsLock = !this.IsLock;
        }
    }
}
