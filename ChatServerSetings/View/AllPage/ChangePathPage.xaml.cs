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

namespace ChatServerSetings.View.AllPage
{
    /// <summary>
    /// Логика взаимодействия для ChangePathPage.xaml
    /// </summary>
    public partial class ChangePathPage : Page
    {
        public ChangePathPage()
        {
            InitializeComponent();
            DataContext = new ViewModel.ChangePathViewModel();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
