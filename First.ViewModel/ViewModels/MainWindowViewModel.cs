namespace First.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
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

