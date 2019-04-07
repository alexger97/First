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
        ObservableCollection<ITask> _tasks = null;

        ObservableCollection<ITask> Tasks
        {
            get
            {if (_tasks == null)
                    _tasks.Add(new MyTask("One", "Ебанько", true, true));
                _tasks.Add(new MyTask("One", "Ебанько", true, true));
                _tasks.Add(new MyTask("One", "Ебанько", true, true));
                return _tasks;
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

        public bool typelist;


        public void ExecuteAddClientCommand(object parameter)
        {

           _tasks.Add(TaskService.GetTask("1"));
            MessageBox.Show("Вроде что-то произошло");
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {


            return true;

        }

       public ObservableCollection<ITask> ObsTask = new ObservableCollection<ITask>
        {
            new MyTask("One","Ебанько",true, true),
           new MyTask("Two","Малыш",false, true),
              new MyTask("Third","Супер",false, true),
                 new MyTask("Four","Киберпанкс",false, false)
        };







    }
}
