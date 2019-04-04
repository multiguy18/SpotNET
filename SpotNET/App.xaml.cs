using SpotNET.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SpotNET
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public void OnStartup(object sender, StartupEventArgs e)
        {
            DirectCtrlView main = new DirectCtrlView();
            main.Show();
        }
    }
}
