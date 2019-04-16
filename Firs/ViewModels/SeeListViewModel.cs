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
    public class SeeListViewModel : ViewModelBase
    {
        private ITaskService _taskService;


        MainWindowViewModel mainWindowViewModel;
        public SeeListViewModel( MainWindowViewModel Vm)///ITaskService taskService)
        {
          //  _taskService = taskService;

           this.mainWindowViewModel = Vm;
            basetask = Refesh();
            Tasks = basetask;
        }

       
        ObservableCollection<IMyTask> _tasks = null;
        MyTask actualTask;

        public MyTask ActualTask
           {
            get { return actualTask; }

            set {
                actualTask = value; OnPropertyChanged("ActualTask");
               // MessageBox.Show(value.Description); 
            }
                    }

        private ObservableCollection<IMyTask> basetask;
        public  ObservableCollection<IMyTask> Tasks
        {
            
            get
            {
               
                return _tasks;
            }

            set
            {
                if ((value) is IMyTask)
                {
                    base.OnPropertyChanged("Tasks");
                    _tasks.Add((IMyTask)value);
                    base.OnPropertyChanged("Tasks");
                }

                if ((value) is ObservableCollection<IMyTask>)
                {

                    _tasks = value; base.OnPropertyChanged("Tasks");
                }
            }

        }
        void oi ()
        {
            var i = from ii in Tasks orderby ii.Name select ii;
            
        }
        



       

        private ObservableCollection<IMyTask> Refesh()
        {
           
            var list = TaskService.ReadAllTasks();
            return new ObservableCollection<IMyTask>(list);
            
           
           

        }
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
            // mainWindowViewModel.CurrentPage = new SeeListTask(this);
            basetask = Refesh();
            Tasks = basetask;
            
            MessageBox.Show("Обновление базы произошло");
        }

        public bool CanExecuteRefeshCommand(object parameter)
        {
          //  if (Tasks.Equals(basetask)) return false;
            return true;
        }

        RelayCommand _editTaskCommand;

        public RelayCommand EditTaskCommand
        {
            get
            {
                if (_editTaskCommand == null) { _editTaskCommand = new RelayCommand(ExecuteEditTaskCommand, CanExecuteEditTaskCommand); }
                        //((o) => { mainWindowViewModel.CurrentPage = new OneTask(ActualTask, mainWindowViewModel); }, canExecute: (o) => { if (ActualTask != null) return true; return false; }); }
                    return _editTaskCommand;


            }

        }


        public void ExecuteEditTaskCommand(object parameter)
        {
            mainWindowViewModel.CurrentPage = new OneTask(ActualTask, mainWindowViewModel);
            mainWindowViewModel.ColorSet(3);
        }
        public bool CanExecuteEditTaskCommand(object parameter)
        {
            if (ActualTask != null) return true; return false;
        }


        string _searchText;
        public string SearchText
        {
            get => _searchText;

            set { _searchText = value;

                OnPropertyChanged("SearchText");
                MessageBox.Show("Сменилось");
            }

        }

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
          

           var rr = basetask.Where(x => x.Name.Contains(SearchText));
         Tasks=   new ObservableCollection<IMyTask>(rr);

            // Tasks = (ObservableCollection)rr;
           
        }
        public bool CanExecuteSearchTaskCommand (object parameter)
        {
            if (SearchText != null) return true;
            return false;
        }

    }





    
}
