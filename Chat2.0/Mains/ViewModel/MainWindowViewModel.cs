using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chat2._0.Mains.ViewModel
{

    internal class MainWindowViewModel : Core.NotifyPropertyChanged
    {
        internal static MainWindowViewModel MainViewModel;

        private Page _CurrentPage;

        private string _CurrentTitle;

        public Page CurrentPage
        {
            get => _CurrentPage;
            set
            {
                _CurrentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public string CurrentTitle
        {
            get => _CurrentTitle;
            set
            {
                _CurrentTitle = value;
                OnPropertyChanged("CurrentTitle");
            }
        }
        public MainWindowViewModel()
        {
            Utilites.Utilites.SetPage = SetCurrentPage;
            Utilites.Utilites.SetPageUtilite(new AllPage.Auth.View.Autorization());
        }

        private void SetTitle(string PageTitle)
        {
            CurrentTitle = PageTitle;
        }


        public void SetCurrentPage(Page page)
        {
            this.CurrentPage = page;
            this.SetTitle(page.Title);
        }
    }
}
