using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using First.Interface;

using First.Model;
using First.Service;

namespace First.ViewModel
{
    public class OneTaskViewModel : ViewModelBase, IOneTaskViewModel
    {
      
        private string _name;
        private string _description;
        private bool _importance;
        private bool _urgency;



        TaskService taskService;

        MyTask actualTask;

        public  OneTaskViewModel(IMyTask myTask, ITaskService service)
        {
                ActualTask = myTask;
            taskService = (TaskService)service;
        }

      

        public IMyTask ActualTask
        {
            get => actualTask;
        set
            {
                if (value != null) { actualTask = (MyTask)value; Name = value.Name; Description = value.Description; UrgencyVM = value.Urgency; ImportanceVM = value.Importance; }

                else { Name = ""; Description = ""; UrgencyVM = false; ImportanceVM = false;

                    actualTask = new MyTask();/// в-принцепи тут можно сделать логику получения из контейнера , но стоит ли ?
                }
                
                OnPropertyChanged("ActualTask");
            }


        }

        // [ToDo] Важность и срочность можно выразить числом, на основании 
        // которого потом можно будет рассчитать это значение? Если да, то лучше так и сделать.
        // Bool значение в данном случае вторично и является продуктом необратимого преобразования.

            // На данный момент считаю, что в контексте данной программы нет смысла хрнанить данные о градации степени важности и срочности задачи. 
            //Это можно реализовать путем внедрения дополнительной логики, но я не вижу смысла усложнять уже существующую логику...
        public bool ImportanceVM
        {

            get
            {
                return _importance;
            }
            set
            {
                _importance = value;  
                 OnPropertyChanged("ImportanceVM");
            }
        }

        public bool UrgencyVM
        {

            get
            {
                return _urgency;
            }
            set
            {
                _urgency = value;              
                 OnPropertyChanged("UrgencyVM");
            }
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;               
                OnPropertyChanged("Name");
            }
        }

          public string   Description
        {
            get { return _description; }

            set { _description = value;              
                OnPropertyChanged("Description");   
            }
        }

    
        private RelayCommand _addCommand;      
        public RelayCommand AddCommand
        {
            get
            {
               if (_addCommand == null)
                    _addCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                return _addCommand;
            }
        }

       

        public void ExecuteAddClientCommand(object parameter)
        {MessageBox.Show("Задача добавлена в Базу");
            ActualTask.Name = Name;
            ActualTask.Description = Description;
            ActualTask.Urgency = UrgencyVM;
            ActualTask.Importance = ImportanceVM;         
            taskService.AddTask((IMyTask)ActualTask);
            ActualTask = null;
            
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {
            if ((!String.IsNullOrWhiteSpace(Name)) && (!string.IsNullOrWhiteSpace(Description))){  return true; }
            return false; 
        }

    }
}
