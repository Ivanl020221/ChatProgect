using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatServerSetings.ViewModel
{
    class ChangePathViewModel : Utilites.NotifyPropertyChanged
    {
        String _path;

        bool _isError;

        public String PathServer
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("pathServer");
            }
        }

        public bool IsError
        {
            get { return _isError; }
            set
            {
                _isError = value;
                OnPropertyChanged("isError");
            }
        }

        public ICommand SaveCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public ChangePathViewModel()
        {
            SaveCommand = new Utilites.Command(SavePath);
            ExitCommand = new Utilites.Command(Utilites.UtilitesProgect.Exit);
        }

        private bool PingServer(string path)
        {
            try
            {
                PingReply reply = new Ping().Send(path);
                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }    
        }

        public void SavePath(object obj)
        {
            if (PingServer(this.PathServer))
            {
                MessageBox.Show($"Path {SaveSettingsChat()} Save");
                this.IsError = false;
            }
            else
            {
                this.IsError = true;
            }
        }

        private string SaveSettingsChat()
        {
            Chat2._0.Properties.Settings.Default.Path = this.PathServer;
            Chat2._0.Properties.Settings.Default.Save();
            return Chat2._0.Properties.Settings.Default.Path;
        }
    }
}
