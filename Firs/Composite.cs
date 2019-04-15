using First.Data;
using First.Interface;
using First.Model;
using First.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

using First.ViewModel;
using System.Windows.Controls;
using System.Reflection;
using First.Views;

namespace First
{
    class Composite
    {
        public static MainWindowViewModel GetMainViewModel()
        {
            IContainer container = BuildContainer();

            var mainViewModel = container.Resolve <MainWindowViewModel> ();
            mainViewModel.CurrentPage = container.Resolve<MainWindowS>();
            
            /*mainViewModel.NavigationService = container.
                Resolve<INavigationService>(
                new NamedParameter("frame", frame));
            */
            return mainViewModel;
        }





        private static IContainer BuildContainer()
        {


          //  var containerBuilder = new ContainerBuilder();
           // var taskListAssembly = Assembly.GetExecutingAssembly();
           // var serviceAssembly = Assembly.GetAssembly(typeof(TaskService));
           /// var repositoryAssembly = Assembly.GetAssembly(typeof(TaskRepository));
            ///var viewModelAssembly = Assembly.GetAssembly(typeof(ViewModelBase));

           /// containerBuilder.RegisterAssemblyTypes(taskListAssembly).Where(t => t.Name.EndsWith("Page",
           ///         StringComparison.CurrentCultureIgnoreCase)).Keyed<Page>(x => x.Name);


            // Место для добавления сервисов
           // containerBuilder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.Name.EndsWith("Service",
           //         StringComparison.CurrentCultureIgnoreCase)).AsImplementedInterfaces().WithParameter("frame", frame);


            var builder = new ContainerBuilder();
            builder.RegisterType<MyTask>().As<IMyTask>();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>();
            builder.RegisterType<TaskService>().As<ITaskService>();
            builder.RegisterType<MainWindowS>().As<IMyMainWindows>();
            // builder.RegisterType<VisitorRepository>().As<IVisitorRepository>();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
           return  builder.Build();

           // var model = container.Resolve<MainWindowViewModel>();
            //var view = new MainWindow()
            //{
             // DataContext =// new MainWindowViewModel()
            //model
            }
            ///view.Show();
        }
    }

