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
           vm.Main = new MainWindowS();/// можно и страницы добавить в контейнер , но придется их тутже выгружать. Не вижу смысла
            vm.CurrentPage = vm.Main;
           vm.OneTask1 = new OneTask();
            vm.ListTasks = new SeeListTask();
            vm.OneTask1.DataContext = vm.OneTaskViewModel;
            vm.ListTasks.DataContext = vm.SeeListViewModel;
        
          var view = new MainWindow() { DataContext = vm};

            
            view.Show();
        }
    }
}
