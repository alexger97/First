using First.Interface;
using First.ViewModel;
using System;
using System.Collections.Generic;
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

namespace First
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           //MainWindow2 mainWindow2= new MainWindow2();
           // mainWindow2.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OneTask oneTask = new OneTask() {DataContext=new OneTaskViewModel() };
            oneTask.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SeeListTask seeListTask = new SeeListTask();//{ DataContext = new SeeListViewModel() };
            seeListTask.Show();
        }

       
    }
}
