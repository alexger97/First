using First.Interface;
using First.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using First;

namespace First
{
    /// <summary>
    /// Логика взаимодействия для SeeOneTask.xaml
    /// </summary>
    public partial class SeeListTask : Window
    {
        public SeeListTask()
        {
            InitializeComponent();
            TaskList.ItemsSource = ObsTask;
        }



            public ObservableCollection<ITask> ObsTask = new ObservableCollection<ITask>
                 {
            new MyTask("One","Ебанько",true, true),
           new MyTask("Two","Малыш",false, true),
              new MyTask("Third","Супер",false, true),
                            new MyTask("Four","Киберпанкс",false, false)  };
    } }


