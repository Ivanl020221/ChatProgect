using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.AllPage.Auth.ViewModel
{
    class AutorizatonViewModel : Core.NotifyPropertyChanged
    {
        public static Entity.Employee CurrentUser { get; set; }
    }
}
