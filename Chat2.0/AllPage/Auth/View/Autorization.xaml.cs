using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat2._0.AllPage.Auth.View
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {

        public Autorization(Mains.ViewModel.MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            this.DataContext =new Auth.ViewModel.AutorizatonViewModel(mainWindowViewModel);
        }
    }
}
