﻿using SpotNET.Model;
using SpotNET.ViewModel;
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
using System.Windows.Shapes;

namespace SpotNET.View
{
    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class DirectCtrlView : Window
    {
        public DirectCtrlView(DMXUniverse universe)
        {
            InitializeComponent();
            DataContext = new DirectCtrlViewModel(universe);
        }
    }
}
