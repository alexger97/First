using Autofac;

using First.Interface;

using First.Integration;
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
            var vm = Composite.MainViewModel;
            vm.NavigationService.First = new OneTask() { DataContext = vm.OneTaskViewModel  };
            vm.NavigationService.Second = new SeeListTask() { DataContext = vm.SeeListViewModel };
            vm.NavigationService.Third = new MainWindowS();
            vm.CurrentPage = vm.NavigationService.Third;
         

            var view = new MainWindow() { DataContext = vm};

            
            view.Show();
        }
    }
}
