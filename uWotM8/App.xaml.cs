using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using uWotM8.model;

namespace uWotM8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Exit(object sender, ExitEventArgs e)
        {
            Model.Instance.save();
        }
    }

}