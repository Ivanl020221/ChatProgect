using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatServerSetings.Utilites
{
    class UtilitesProgect
    {
        public static void Exit(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
