using First.Interface;
using First.Model;
using First.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace First.ViewModel
{
   public class SeeListViewModel:ViewModelBase
    {
        ObservableCollection<ITask> _tasks = new ObservableCollection<ITask>
        {
            new MyTask("One", "Ебанько", true, true),
        new MyTask("One", "Ебанько", false, true),
        new MyTask("One", "Ебанько", true, true),
        new MyTask("One", "Ебанько", false, true)
        };

       public  ObservableCollection<ITask> Tasks
        {
            get
            {
                return _tasks;
            }

            set
            {
                base.OnPropertyChanged("Tasks");
                _tasks.Add((ITask)value);
                base.OnPropertyChanged("Tasks");
            }

        }





        RelayCommand _readCommand;

     public  RelayCommand ReadCommand
        {
            get
            {
                if (_readCommand == null)
                    _readCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                return _readCommand;
            }

        }



        public void ExecuteAddClientCommand(object parameter)
        {

           _tasks.Add(TaskService.GetTask("1"));
            MessageBox.Show("Вроде что-то произошло");
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {


            return true;

        }

       







    }
}
