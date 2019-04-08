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
            var builder = new ContainerBuilder();
            builder.RegisterType<MyTask> ().As<Interface.ITask>();
            builder.RegisterType<TaskRepository> ().As<ITaskRepository>();
            builder.RegisterType<TaskService>().As<ITaskService>();
          //  builder.RegisterType<VisitorRepository>().As<IVisitorRepository>();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            var container = builder.Build();
            var model = container.Resolve<MainWindowViewModel>();
            var view = new MainWindow() { DataContext = new MainWindowViewModel()}  ;
            view.Show();
        }
    }
}
