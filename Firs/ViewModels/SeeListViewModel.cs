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

        public  ObservableCollection<IMyTask> Tasks
        {
            
            get
            {
                if (_tasks == null)
                {
                    _tasks = new ObservableCollection<IMyTask>();

                    List<IMyTask> _list = Refesh();
                    if (_list != null)
                    {
                        foreach(Model.MyTask task in _list )
                        {
                            _tasks.Add(task);
                        }
                        MessageBox.Show("Актуальное состояние базы");
                    } else { MessageBox.Show("Нет задач в базе данных"); }
                    
                }
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


                }
            }

        }
        void oi ()
        {
            var i = from ii in Tasks orderby ii.Name select ii;
            
        }
        



       

        private List<IMyTask> Refesh()
        {
           
            var list = TaskService.ReadAllTasks();
            if (list != null)

                return list;
            else return null;
            
           
           

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

            this.Tasks = null;
            MessageBox.Show("@@@@@");
        }

        public bool CanExecuteRefeshCommand(object parameter)
        {
            Thread.Sleep(50);
            return true;
        }

        RelayCommand _editTaskCommand;

        public RelayCommand EditTaskCommand
        {
            get
            {
                if (_editTaskCommand == null) { _editTaskCommand = new RelayCommand(ExecuteEditTaskCommandCommand, CanExecuteRefeshCommandCommand); }
                        //((o) => { mainWindowViewModel.CurrentPage = new OneTask(ActualTask, mainWindowViewModel); }, canExecute: (o) => { if (ActualTask != null) return true; return false; }); }
                    return _editTaskCommand;


            }

        }


        public void ExecuteEditTaskCommandCommand(object parameter)
        {
            mainWindowViewModel.CurrentPage = new OneTask(ActualTask, mainWindowViewModel);
            mainWindowViewModel.ColorSet(3);
        }
        public bool CanExecuteRefeshCommandCommand(object parameter)
        {
            if (ActualTask != null) return true; return false;
        }










    }
}
