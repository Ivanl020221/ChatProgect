﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chat2._0.Entity;
using Chat2._0.Utilites;
using static Chat2._0.Utilites.ApiConnect;
using static Chat2._0.Utilites.ParamsGenerator;

namespace Chat2._0.Mains.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new Mains.ViewModel.MainWindowViewModel();
        }

       
    }
}