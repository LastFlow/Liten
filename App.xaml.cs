﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Liten
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void Att(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вниманье", "Оптимизации онли софтверные в этой версии");
        }
    }
}