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
using First.Model;

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

                    var Localservice = GetLocalTaskService();
                    var Serverservice = GetServerTaskService("https://localhost:44301/api/Task/");
                    
                   
                    var NavService = Container.Resolve<INavigationService>();

                    _MainViewModel = Container.Resolve<IMainViewModel>(new NamedParameter("navigationService", NavService), new NamedParameter("serviceLoc", Localservice), new NamedParameter("serviceServer", Serverservice));

                    var settingsVM = Container.Resolve<ISettingsViewModel>(new NamedParameter("Vm", _MainViewModel));

                    var seelistvm = Container.Resolve<ISeeListViewModel>(new NamedParameter("Vm", _MainViewModel));

                    var onetaskvm = Container.Resolve<IOneTaskViewModel>(
                      new NamedParameter("myTask", null),
                      new NamedParameter("Vm",_MainViewModel)
                      );
                   
                   
                }

                return _MainViewModel;
            }
        }
        #region Repository
        public static IServerRepository GetServerTaskRepository() //(string adress)
        {
            return Container.Resolve<IServerRepository>();//;(new NamedParameter("adress",adress));

        }


        public static ITaskRepository GetLocalTaskRepository()
        {
            
            return Container.Resolve<ITaskRepository>();

        }
        #endregion

        #region Services
        public static ITaskService<ITaskRepository> GetLocalTaskService()
        {
            return Container.Resolve<ITaskService<ITaskRepository>>(new NamedParameter("repository", GetLocalTaskRepository()));
        }

        public static ITaskService<IServerRepository> GetServerTaskService(string adress)
        {
            return Container.Resolve<ITaskService<IServerRepository>>(new NamedParameter("_serverData", GetServerTaskRepository()));
        }

        #endregion
        #region Container
        private static IContainer BuildContainer()
        {

            var containerBuilder = new ContainerBuilder();
   
            var serviceAssembly = Assembly.GetAssembly(typeof(TaskServerService));
            
            var repositoryAssembly = Assembly.GetAssembly(typeof(TaskRepository));
            var viewModelAssembly = Assembly.GetAssembly(typeof(ViewModelBase));

            //локал сервис
            containerBuilder.RegisterType<TaskLocalService>().As<ITaskService<ITaskRepository>>().AsSelf();
            // удаленный сервис
            containerBuilder.RegisterType<TaskServerService>().As<ITaskService<IServerRepository>>().AsSelf();

           
            containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            
            containerBuilder.RegisterType<MyTask>().As<IMyTask>();
            containerBuilder.RegisterType<User>().As<IUser>();
            containerBuilder.RegisterAssemblyTypes(repositoryAssembly).Where(t => t.Name.EndsWith("Repository",
                   StringComparison.CurrentCultureIgnoreCase)).AsImplementedInterfaces();


            containerBuilder.RegisterAssemblyTypes(viewModelAssembly)
                .Where(x => x.Name.EndsWith("ViewModel", StringComparison.InvariantCultureIgnoreCase))
                .AsImplementedInterfaces()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).SingleInstance();
                

            return containerBuilder.Build();
        }

        #endregion

    }
}
