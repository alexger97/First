using System.Windows.Controls;


namespace First
{
    /// <summary>
    /// Логика взаимодействия для SeeOneTask.xaml
    /// </summary>
    public partial class SeeListTask : Page
    {
        public SeeListTask()
        {
            InitializeComponent();
         //  DataContext= new SeeListViewModel((MainWindowViewModel)vm);
            radioButton1.IsChecked = true;
        }

       
    } }


