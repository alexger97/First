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
    public class OneTaskViewModel: ViewModelBase
    {

    
        
        
        // TaskService taskService = new TaskService();
      private string _name;
        private string _description;
       private bool _importance;
        private bool _urgency;

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

       // bool isactive1 = false;
        //bool isactive2 = false;
        public bool ImportanceVM
        {
            get { return _importance; }

            set
            {
               // isactive1 = true;
               _importance = value;
                OnPropertyChanged("ImportanceVM");
                MessageBox.Show(ImportanceVM.ToString());
            }
        }

        public bool UrgencyVM
        {
            get { return _urgency; }

            set
            {
              //  isactive2= true;
                _urgency = value;
                OnPropertyChanged("UrgencyVM");
                MessageBox.Show(UrgencyVM.ToString());
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
        {MessageBox.Show("Вроде что-то произошло");

            //TaskService.AddTaskService(new MyTask(_name, _description, _importance, _urgency));
            
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {

            if ((!String.IsNullOrWhiteSpace(Name)) && (!string.IsNullOrWhiteSpace(Description))){  return true; }

            //  MessageBox.Show("Условия не норм"); 
            return false; return true;


        }




    }
}
