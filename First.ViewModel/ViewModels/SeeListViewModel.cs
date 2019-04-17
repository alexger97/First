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
        private TaskService _taskService;
        MainWindowViewModel mainWindowViewModel;

     public   IMainViewModel MainWindowViewModel { get => mainWindowViewModel;

            set { mainWindowViewModel = (MainWindowViewModel) value; }
        }


        public SeeListViewModel(IMainViewModel Vm ,ITaskService taskService)
        {
           _taskService = (TaskService) taskService;

            MainWindowViewModel =  Vm;
            basetask = Refesh();
           Tasks = basetask;
        }

       
       
        MyTask actualTask;

        public IMyTask ActualTask
           {
            get { return actualTask; }

            set {
                actualTask = (MyTask)value; OnPropertyChanged("ActualTask");
               // MessageBox.Show(value.Description); 
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
       

      private ObservableCollection<IMyTask> Refesh()
         {

     var list = _taskService.ReadAllTasks();
        
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
           
          basetask = Refesh();
            if (basetask.Count == 0) { MessageBox.Show("База пуста"); }
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
            MainWindowViewModel.OneTaskViewModel.Name = ActualTask.Name;
            MainWindowViewModel.OneTaskViewModel.Description = ActualTask.Description;
            MainWindowViewModel.OneTaskViewModel.ImportanceVM = ActualTask.Importance;
            MainWindowViewModel.OneTaskViewModel.UrgencyVM = ActualTask.Urgency;
            MainWindowViewModel.SlowOpacity(MainWindowViewModel.OneTask1);

            //mainWindowViewModel.CurrentPage = new OneTask(ActualTask, mainWindowViewModel);
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
          

           var rr = basetask.Where(x => x.Name.Contains(SearchText.ToUpper())|| x.Name.Contains(SearchText.ToLower()));
         Tasks=   new ObservableCollection<IMyTask>(rr);

            // Tasks = (ObservableCollection)rr;
           
        }
        public bool CanExecuteSearchTaskCommand (object parameter)
        {
            if (SearchText != null) return true;
            return false;
        }







        RelayCommand _deleteTaskCommand;

        public RelayCommand DeleteTaskCommand
        {
            get
            {
                if (_deleteTaskCommand == null) { _deleteTaskCommand = new RelayCommand(ExecuteDeleteTaskCommand, CanExecuteDeleteTaskCommand); }

                return _deleteTaskCommand;
            }
        }



        public void ExecuteDeleteTaskCommand(object parameter)
        {
           

            _taskService.DelTask(ActualTask.Name);
            // Tasks = (ObservableCollection)rr;
            ExecuteRefeshCommand(null);
        }
        public bool CanExecuteDeleteTaskCommand(object parameter)
        {
            if (ActualTask != null) return true;
            return false;
        }






    }





    
}
