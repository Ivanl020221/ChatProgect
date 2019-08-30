using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chat2._0.Mains.ViewModel
{

    class MainWindowViewModel : Core.NotifyPropertyChanged
    {
        public Page CurrentPage { get; set; }

        public string CurrentTitle { get; set; }

        public MainWindowViewModel()
        {
            this.SetCurrentPage(new AllPage.Auth.View.Autorization());
        }

        private void SetTitle(string PageTitle)
        {
            CurrentTitle = PageTitle;
        }

        private void SetCurrentPage(Page page)
        {
            this.CurrentPage = page;
            this.SetTitle(page.Title);
        }
    }
}
