using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First.Interface;
using First.Service;
using Autofac;
using First.ViewModel;
using First.Data;
using System.Reflection;

namespace First.Integration
{
    public class Composite
    {
        static IContainer container;
        public static IContainer Container
        {
            get
            {
                if (container == null)
                { container = BuildContainer(); }
                return container;
            }

            set
            {
                container = value;
            }

        }
        private static IMainViewModel _MainViewModel;

        public static IMainViewModel MainViewModel
        {
            get
            {
                if (_MainViewModel == null)
                {
                   
                   var service= Container.Resolve<ITaskService>(new NamedParameter("repository", GetTaskRepository()));

                    var onetaskvm = Container.Resolve<IOneTaskViewModel>(new NamedParameter("myTask", null),
                      new NamedParameter("viewModelBase", _MainViewModel),
                      new NamedParameter("service", service));

                    var seelistvm = Container.Resolve<ISeeListViewModel>(new NamedParameter("Vm", _MainViewModel),
                         new NamedParameter("taskService", service));
                    _MainViewModel = Container.Resolve<IMainViewModel>(new NamedParameter("oneTaskViewModel", onetaskvm), new NamedParameter("seeListViewModel", seelistvm));
                   
                }

                return _MainViewModel;
            }
        }


        public static ITaskRepository GetTaskRepository()
        {
            return Container.Resolve<ITaskRepository>();

        }

        public static ITaskService GetTaskService()
        {
            return Container.Resolve<ITaskService>(new NamedParameter("repository", GetTaskRepository()));

        }


        private static IContainer BuildContainer()
        {


            var containerBuilder = new ContainerBuilder();
            //var taskListAssembly = Assembly.GetExecutingAssembly();
            var serviceAssembly = Assembly.GetAssembly(typeof(TaskService));
            var repositoryAssembly = Assembly.GetAssembly(typeof(TaskRepository));
            var viewModelAssembly = Assembly.GetAssembly(typeof(ViewModelBase));




            // containerBuilder.RegisterType<MainWindowS>().AsSelf();
            //containerBuilder.RegisterType<OneTask>().AsSelf();
            // containerBuilder.RegisterType<SeeListTask>().AsSelf();
            // Место для добавления сервисов
            containerBuilder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.Name.EndsWith("Service",
                  StringComparison.CurrentCultureIgnoreCase)).AsImplementedInterfaces();
            // Место для добавления репозиториев
            containerBuilder.RegisterAssemblyTypes(repositoryAssembly).Where(t => t.Name.EndsWith("Repository",
                   StringComparison.CurrentCultureIgnoreCase)).AsImplementedInterfaces();




            containerBuilder.RegisterAssemblyTypes(viewModelAssembly)
                .Where(x => x.Name.EndsWith("ViewModel", StringComparison.InvariantCultureIgnoreCase))
                .AsImplementedInterfaces()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            //var builder = new ContainerBuilder();
            //builder.RegisterType<MyTask>().As<IMyTask>();
            /// builder.RegisterType<TaskRepository>().As<ITaskRepository>();
         //   containerBuilder.RegisterType<TaskService>().As<ITaskService>();
            //  builder.RegisterType<MainWindowS>().As<IMainWindows>();
            // builder.RegisterType<VisitorRepository>().As<IVisitorRepository>();
            // builder.RegisterType<MainWindowViewModel>().AsSelf();


            return containerBuilder.Build();


        }



    }
}
