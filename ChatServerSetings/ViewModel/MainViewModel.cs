using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatServerSetings.ViewModel
{
    public class MainViewModel : Utilites.NotifyPropertyChanged
    {
        private Page _CurrectPage;

        internal static MainViewModel MainView;

        public Page CurrectPage
        {
            get { return _CurrectPage; }
            set
            {
                _CurrectPage = value;
                OnPropertyChanged("CurrectPage");
            }
        }

        public MainViewModel()
        {
            SetPage(new View.AllPage.LoginPage());
            MainView = this;
        }

        public void SetPage(Page page)
        {
            CurrectPage = page;
        }
    }
}
