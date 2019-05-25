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

        public IMainViewModel MainWindowViewModel { get; set; }
        
        MyTask actualTask;

        public OneTaskViewModel(IMyTask myTask, IMainViewModel Vm) 
        {
            ActualTask = myTask;
            
            MainWindowViewModel = Vm;
            Vm.OneTaskViewModel = this;
        }


        
        public IMyTask ActualTask
        {
            get => actualTask;
        set
            {
                if (value != null)
                {
                    actualTask = (MyTask)value; Name = value.Name; Description = value.Description; UrgencyVM = value.Urgency; ImportanceVM = value.Importance;
                    MessageBox.Show(actualTask.Id.ToString());
                }

                else { Name = ""; Description = ""; UrgencyVM = false; ImportanceVM = false;

                    actualTask = new MyTask();
                   
                }
                
                OnPropertyChanged("ActualTask");
            }
        }

        #region Property      
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

        #endregion
        #region Add
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
        {
            ActualTask.Name = Name;
            ActualTask.Description = Description;
            ActualTask.Urgency = UrgencyVM;
            ActualTask.Importance = ImportanceVM;
           
            if (MainWindowViewModel.UseServer)
            {
                if (ActualTask.Id != 0)
                {
                    MainWindowViewModel.ServerService.EditTask((MyTask)ActualTask);
                }
                   else MainWindowViewModel.ServerService.AddTask(ActualTask);

            }
           
            else
            {
                MainWindowViewModel.LocalService.AddTask((MyTask)ActualTask);
            }
            ActualTask = null;
            MessageBox.Show("Задача добавлена в Базу");
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {
            if ((!String.IsNullOrWhiteSpace(Name)) && (!string.IsNullOrWhiteSpace(Description))){  return true; }
            return false; 
        }
        #endregion
    }
}
