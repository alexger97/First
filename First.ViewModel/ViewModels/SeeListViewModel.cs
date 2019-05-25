using First.Interface;
using First.Model;
using First.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using First.ViewModel;

namespace First.ViewModel
{
    public class SeeListViewModel : ViewModelBase, ISeeListViewModel
    {
      
        MainWindowViewModel mainWindowViewModel;

        public  IMainViewModel MainWindowViewModel
        {
            get => mainWindowViewModel;
            set
            {
                mainWindowViewModel = (MainWindowViewModel) value;
            }
        }

        public SeeListViewModel(IMainViewModel Vm )
        {
            
            MainWindowViewModel =  Vm;
            basetask = Refesh();
            Tasks = basetask;
            Vm.SeeListViewModel = this;
            
        }
        string _searchText;
        public string SearchText
        {
            get => _searchText;

            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }

        }

        IMyTask actualTask;

        public IMyTask ActualTask
           {
            get { return actualTask; }

            set
            {
                actualTask = (MyTask)value; OnPropertyChanged("ActualTask"); 
            }

        }

        ObservableCollection<IMyTask> _tasks;
        private ObservableCollection<IMyTask> basetask;
        public  ObservableCollection<IMyTask> Tasks
        {
            get
            {
                return _tasks;
            }

            set
            {
                    _tasks = value;
                    base.OnPropertyChanged("Tasks");
            }

        }
       

      private ObservableCollection<IMyTask> Refesh()
        {
            List<IMyTask> list;
            if (MainWindowViewModel.UseServer)
            {
                list = MainWindowViewModel.ServerService.ReadAllTasks();
               
            }
            else
            {
                list = MainWindowViewModel.LocalService.ReadAllTasks();
                 
            }
        return  new ObservableCollection<IMyTask>(list);
        }

        #region Commands
        #region Refesh
        RelayCommand _refeshCommand;
        public  RelayCommand RefeshCommand
        {
            get
            {
                if (_refeshCommand == null)
                    _refeshCommand = new RelayCommand(ExecuteRefeshCommand, CanExecuteRefeshCommand);
                return _refeshCommand;
            }

        }
        public void ExecuteRefeshCommand(object parameter)
        {
            basetask = Refesh();
            if (basetask.Count == 0) { MessageBox.Show("База пуста"); }
            Tasks = basetask;   
        }

        public bool CanExecuteRefeshCommand(object parameter)
        {
            return true;
        }
        #endregion
        #region Edit
        RelayCommand _editTaskCommand;

        public RelayCommand EditTaskCommand
        {
            get
            {
                if (_editTaskCommand == null) { _editTaskCommand = new RelayCommand(ExecuteEditTaskCommand, CanExecuteEditTaskCommand); }
                    return _editTaskCommand;
            }

        }


        public void ExecuteEditTaskCommand(object parameter)
        {
            MainWindowViewModel.OneTaskViewModel.ActualTask = ActualTask;
            MainWindowViewModel.SlowOpacity((IView)MainWindowViewModel.NavigationService.First);
            mainWindowViewModel.ColorSet(3);
        }
        public bool CanExecuteEditTaskCommand(object parameter)
        {
            if (ActualTask != null) return true; return false;
        }
        #endregion

        #region Search
       
        RelayCommand _searchTaskCommand;

        public RelayCommand SearchTaskCommand
        {
            get
            {
                if (_searchTaskCommand == null) { _searchTaskCommand = new RelayCommand(ExecuteSearchTaskCommand, CanExecuteSearchTaskCommand); }
                return _searchTaskCommand;
            }
        }

     

        public void ExecuteSearchTaskCommand(object parameter)
        {
           var rr = basetask.Where(x => x.Name.Contains(SearchText.ToUpper())|| x.Name.Contains(SearchText.ToLower()));
         Tasks=   new ObservableCollection<IMyTask>(rr);
        }
        public bool CanExecuteSearchTaskCommand (object parameter)
        {
            if (SearchText != null) return true;
            return false;
        }
        #endregion
        #region Delete
        RelayCommand _deleteTaskCommand;

        public RelayCommand DeleteTaskCommand
        {
            get
            {
                if (_deleteTaskCommand == null)
                {
                    _deleteTaskCommand = new RelayCommand(ExecuteDeleteTaskCommand, CanExecuteDeleteTaskCommand);
                }

                return _deleteTaskCommand;
            }
        }



        public void ExecuteDeleteTaskCommand(object parameter)
        {
            if (MainWindowViewModel.UseServer)
            {
                MainWindowViewModel.ServerService.DelTask(ActualTask);
                
            }
            else MainWindowViewModel.LocalService.DelTask(ActualTask);

            ExecuteRefeshCommand(null); OnPropertyChanged("Tasks");
        }
        public bool CanExecuteDeleteTaskCommand(object parameter)
        {
            if (ActualTask != null) return true;
            return false;
        }

        #endregion
        #endregion
    }

}
