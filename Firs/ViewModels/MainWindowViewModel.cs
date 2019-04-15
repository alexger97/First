using First.Model;
using First.Views;
using First.Service;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace First.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static NavigationService nv = new NavigationService();



        private Page Main;
        private Page OneTask1;
        private Page ListTasks;

        
    

        private Page _currentPage;
    
        public Page CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged("CurrentPage");   } }

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

        public MainWindowViewModel()
        {
            //Main = new MainWindowS();
            ///{ DataContext = new OneTaskViewModel()};

            ColorSet(0);
            CurrentPage = Main;
            FrameOpacity = 1;

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
           // Page li = new OneTask();
          //  nv.Navigate()
            // OneTask = new OneTask(new MyTask { Name="22",Description="55",Urgency=true,Importance=true}, this); SlowOpacity(OneTask);
            //ColorSet(1);


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
            
            ListTasks = new SeeListTask((ViewModelBase)this); SlowOpacity(ListTasks);
            ColorSet(2);
        }
        public bool CanExecuteCliclTwo (object parameter)
        {
            return true;
        }






        private async void SlowOpacity(Page page)
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

