using First.Interface;
using System.Windows.Controls;


namespace First
{
    /// <summary>
    /// Логика взаимодействия для SeeOneTask.xaml
    /// </summary>
    public partial class SeeListTask : Page, IView
    {
        public SeeListTask()
        {
            InitializeComponent();
       
            radioButton1.IsChecked = true;
        }

       
    } }


