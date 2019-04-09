using First.Views;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace First.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {


        private Page Main;
        private Page OneTask;
        private Page ListTasks;


        private Page _currentPage;
    
        public Page CurrentPage { get => _currentPage; set { _currentPage = value; OnPropertyChanged("CurrentPage"); } }

        private double _frameOpacity;
        public double FrameOpacity
        { get => _frameOpacity;
            set { _frameOpacity = value; OnPropertyChanged("FrameOpacity"); }
        }

        public MainWindowViewModel()
        {
            Main = new MainWindowS();
            OneTask = new OneTask() { DataContext = new OneTaskViewModel()};
            ListTasks = new SeeListTask();

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
            SlowOpacity(OneTask);
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
            SlowOpacity(ListTasks);
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





        RelayCommand _openAddCommand;
    //    RelayCommand OpenAddCommnd
       // {
          //  get { if (_openAddCommand== null)
             //   {
             //       _openAddCommand = new RelayCommand(ExecuteOpenAddCommnd, CanExecuteOpenAddCommnd);
             //       return _openAddCommand;
             //   }
             //           }

            public void ExecuteOpenAddCommnd(object parameter)
        {
            //Frame.
            //

        }
        public bool CanExecuteAddClientCommand(object parameter)
        {

            return true;

        }

    }
    }

