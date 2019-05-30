using First.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using First.Interface;

namespace First.ViewModel.ViewModels
{
    class SettingsViewModel:ViewModelBase, ISettingsViewModel
    {
        public SettingsViewModel(IMainViewModel Vm)
        {
            this.Vm = Vm;
            Vm.SettingsViewModel = this;
        }
        public IMainViewModel Vm;

        private string name;
        private string password;
        private string password2;
        private bool addusertrue;
        private string username;

        private bool useServer;
        public bool UseServer { get => useServer; set { useServer = value; OnPropertyChanged("UseServer"); } }
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }
        public string Password2 { get => password2; set { password2 = value; OnPropertyChanged("Password2"); } }
        public bool AddUser { get => addusertrue; set { addusertrue = value; OnPropertyChanged("AddUser"); } }

        public string UserName { get => username; set { username = value; OnPropertyChanged("UserName"); } }

        private string stateText;
        public string StateText
        {
            get
            {
                return stateText;
            }

            set
            {
                stateText = value; OnPropertyChanged("StateText");
            }
        }

        private Brush stateColor;
        public Brush StateColor
        {
            get
            {
                return stateColor;
            }

            set
            {

                stateColor = value;OnPropertyChanged("StateColor");
            }

        }





        RelayCommand _cliclSettingsLogin;

        public RelayCommand CliclSettingsLogin
        {
            get
            {
                if (_cliclSettingsLogin == null)
                {
                    _cliclSettingsLogin = new RelayCommand(ExecuteCliclSettingsLogin, CanExecuteCliclSettingsLogin);
                }
                return _cliclSettingsLogin;
            }
        }



        public void ExecuteCliclSettingsLogin(object parameter)
        {

           object[] auth= new object[2]{ Name,Password};
            dynamic user; 

            if (!AddUser)
            {
                 user = Vm.ServerService.LoginUser(auth);
               
            }
            else
            {
                user = Vm.ServerService.AddUser(auth);
            }
            if (user != null)
            {

                StateColor = (Brush)System.ComponentModel.TypeDescriptor
          .GetConverter(typeof(Brush)).ConvertFromInvariantString("Green");
                //new SolidColorBrush(Color.FromRgb(177, 255, 10));
                StateText = " √ Успешно";
                Vm.User = user;
                UserName = Vm.User.Name;
            }
            else
            {
                StateColor = (Brush)System.ComponentModel.TypeDescriptor
          .GetConverter(typeof(Brush)).ConvertFromInvariantString("Red");
                //new SolidColorBrush(Color.FromRgb(0, 100, 100));
                StateText = "X Ошибка";
            }

        }
        public bool CanExecuteCliclSettingsLogin(object parameter)
        {
            if(AddUser)
            { if (Password == Password2 && Password != null && Password.Length > 5) return true;
                else return false;
            }
            else
            { 
            if (Password != null && Name != null) return true; return false;
            }
        }



    }
}
