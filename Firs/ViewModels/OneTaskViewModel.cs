using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using First.Controllers;
using First.Interface;

using First.Model;
using First.Service;

namespace First.ViewModel
{
    public class OneTaskViewModel : ViewModelBase
    {
        /*  public static readonly DependencyProperty ImportanceProperty;
          public static readonly DependencyProperty UrgencyProperty;
          static OneTaskViewModel()
              {
              ImportanceProperty = DependencyProperty.Register("ImportanceVM", typeof(bool), typeof(OneTaskViewModel), null);
              UrgencyProperty = DependencyProperty.Register("UrgencyVM", typeof(bool), typeof(OneTaskViewModel), null);
          }
         */
        private string _name;
        private string _description;
        private bool _importance;
        private bool _urgency;


        

        public  OneTaskViewModel(IMyTask myTask, ViewModelBase viewModelBase)
        {
            ActualTask = (MyTask)myTask;
            mainWindowViewModel = (MainWindowViewModel) viewModelBase;
        }

        MainWindowViewModel mainWindowViewModel;
        MyTask actualTask;

        public MyTask ActualTask
        {
            get => actualTask;

            set
            {

                if (value != null) { actualTask = value; Name = value.Name; Description = value.Description; UrgencyVM = value.Urgency; ImportanceVM = value.Importance; }

                else { Name = String.Empty; Description = String.Empty; UrgencyVM = false; ImportanceVM = false; actualTask = new MyTask(); }
                
                OnPropertyChanged("ActualTask");
            }


        }






        public bool ImportanceVM
        {

            get
            {
                return _importance;
              // return (bool)GetValue(ImportanceProperty);
            }
            set
            {
                _importance = value;
                //  SetValue(ImportanceProperty, value);
               ActualTask.Importance = value;
                 OnPropertyChanged("ImportanceVM");

              MessageBox.Show("Importance"+ImportanceVM.ToString());


            }
        }

        public bool UrgencyVM
        {

            get
            {
                return _urgency;
               // return (bool)GetValue(UrgencyProperty);
            }
            set
            {
                _urgency = value;
               ActualTask.Urgency = value;
               // SetValue(UrgencyProperty, value);
                 OnPropertyChanged("UrgencyVM");

                MessageBox.Show("Urgency"+UrgencyVM.ToString());


            }
        }



       


        // TaskService taskService = new TaskService();


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                ActualTask.Name = value;
                OnPropertyChanged("Name");
            }
        }

          public string   Description
        {
            get { return _description; }

            set { _description = value;
                ActualTask.Description = value;
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
        {MessageBox.Show("Вроде что-то произошло");

            TaskService.AddTaskService((IMyTask)ActualTask);
            ActualTask = null;
            
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {

            if ((!String.IsNullOrWhiteSpace(Name)) && (!string.IsNullOrWhiteSpace(Description))){  return true; }

            //  MessageBox.Show("Условия не норм"); 
            return false; return true;


        }




    }
}
