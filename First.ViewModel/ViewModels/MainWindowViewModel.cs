using First.Model;

using First.Service;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using First.Interface;
using System.Security;
using System.Net;

namespace First.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IMainViewModel
    {
        

        public IUser User { get; set; }
        
        // public enum VariantsofStateReqest { notreqest, goodresult,badresult }
       

        //не забыть привести в порядок
        //public SecureString SecurePassword { private get; set; }

        public ISettingsViewModel SettingsViewModel { get; set; }
        public  IOneTaskViewModel OneTaskViewModel { get; set; }
        public  ISeeListViewModel SeeListViewModel { get; set; }
        public  INavigationService NavigationService { get; set; }

        public ITaskService<ITaskRepository> LocalService { get; set; }
        public ITaskService<IServerRepository> ServerService { get; set; }

        public MainWindowViewModel(INavigationService navigationService, ITaskService<ITaskRepository> serviceLoc, ITaskService<IServerRepository> serviceServer)
        {
            NavigationService = navigationService;
            LocalService = serviceLoc;
            ServerService = serviceServer;

            ColorSet(0);
            CurrentPage = NavigationService.Third;
            FrameOpacity = 1;
          
        }



        private IView _currentPage;

        public IView CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged("CurrentPage"); } }




        private Brush _colorButton1;
        private Brush _colorButton2;
        private Brush _colorButton3;

        public Brush ColorButton1
        {
            get => _colorButton1;
            set { _colorButton1 = value;
                OnPropertyChanged("ColorButton1");
            }

        }
        public Brush ColorButton2
        {
            get => _colorButton2;
            set
            {
                _colorButton2 = value;
                OnPropertyChanged("ColorButton2");
            }

        }
        public Brush ColorButton3
        {
            get => _colorButton3;
            set
            {
                _colorButton3 = value;
                OnPropertyChanged("ColorButton3");
            }
           
        }

        public void ColorSet(short i)
        {
            var supcolor = new SolidColorBrush(Color.FromRgb(177, 255, 10));
            var othercolor= new SolidColorBrush(Color.FromRgb(2, 255, 29));
            if (i == 1) { ColorButton1 = supcolor; ColorButton2 = othercolor; ColorButton3 = othercolor;  }
            if (i == 2) { ColorButton2 = supcolor; ColorButton1 = othercolor; ColorButton3 = othercolor; }
            if (i == 3) { ColorButton3 = supcolor; ColorButton2 = othercolor; ColorButton1 = othercolor; }
            if (i==0) { ColorButton3 = ColorButton2 = ColorButton1 = othercolor; }
        }

        private double _frameOpacity;
        public double FrameOpacity
        { get => _frameOpacity;
            set { _frameOpacity = value; OnPropertyChanged("FrameOpacity"); }
        }

       

        RelayCommand _cliclOne;

        public RelayCommand CliclOne
        {
            get
            {
                if (_cliclOne == null)
                {
                    _cliclOne = new RelayCommand(ExecuteCliclOne, CanExecuteCliclOne);
                }
                return _cliclOne;
            }
        }

            public void ExecuteCliclOne(object parameter)
        {
            OneTaskViewModel.Name = "";
            OneTaskViewModel.Description = "";
            OneTaskViewModel.ImportanceVM = false;
            OneTaskViewModel.UrgencyVM = false;
            SlowOpacity(NavigationService.First);
            ColorSet(1);
        }
        public bool CanExecuteCliclOne(object parameter)
        {
            return true;
        }


        RelayCommand _cliclTwo;

        public RelayCommand CliclTwo
        {
            get
            {
                if (_cliclTwo== null)
                {
                    _cliclTwo = new RelayCommand(ExecuteCliclTwo, CanExecuteCliclTwo);
                }
                return _cliclTwo;
            }
        }

      

        public void ExecuteCliclTwo(object parameter)
        {
            SlowOpacity(NavigationService.Second);
            ColorSet(2);
        }
        public bool CanExecuteCliclTwo (object parameter)
        {
            return true;
        }


        RelayCommand _cliclSettings;

        public RelayCommand CliclSettings
        {
            get
            {
                if (_cliclSettings == null)
                {
                    _cliclSettings = new RelayCommand(ExecuteCliclSettings, CanExecuteCliclSettings);
                }
                return _cliclSettings;
            }
        }



        public void ExecuteCliclSettings(object parameter)
        {
            SlowOpacity(NavigationService.SettingsPage);
            ColorSet(2);
        }
        public bool CanExecuteCliclSettings(object parameter)
        {
            return true;
        }






        public async void SlowOpacity(IView page)
        {
            await Task.Factory.StartNew(() =>

            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                   FrameOpacity = i;
                    Thread.Sleep(50);

                }
              
               CurrentPage = page;
               
                for (double i = 0; i < 1.1; i += 0.1)
                {
                FrameOpacity = i;
                    Thread.Sleep(50);

                }

            });

        }

       
    }
    }

