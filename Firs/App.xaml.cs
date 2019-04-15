using Autofac;
using First.Data;
using First.Interface;

using First.Model;
using First.Service;
using First.ViewModel;
using First.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace First
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
           var view= new MainWindow() { DataContext = Composite.GetMainViewModel() };
            view.Show();
        }
    }
}
