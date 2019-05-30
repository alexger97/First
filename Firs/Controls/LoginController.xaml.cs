using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing.Imaging;
using First.Interface;
using static First.ViewModel.MainWindowViewModel;
using System.Threading;
using System.ComponentModel;

namespace First.Controls
{
    /// <summary>
    /// Логика взаимодействия для LoginController.xaml
    /// </summary>
    public partial class LoginController :UserControl
    {
        public LoginController()
        {
            //StateRequest = VariantsofStateReqest.goodresult;
            InitializeComponent();
            
        }

        

        public static readonly DependencyProperty PasswordBoxProperty;
        public static readonly DependencyProperty PasswordBox2Property;
        public static readonly DependencyProperty PasswordProperty;
        public static readonly DependencyProperty Password2Property;
        public static readonly DependencyProperty LoginProperty;
        public static readonly DependencyProperty AddUserTrueProperty;
        public static readonly DependencyProperty CommandButtonProperty;

       public static readonly DependencyProperty StateColorProperty;
       public static readonly DependencyProperty StateTextProperty;

        public static readonly DependencyProperty UserNameProperty;
        // public static readonly DependencyProperty StateRequestProperty;
        static LoginController()
        {
            PasswordBoxProperty = DependencyProperty.Register("PasswordBox", typeof(PasswordBox), typeof(LoginController), new PropertyMetadata(null));
            PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(LoginController), new PropertyMetadata(null));
            Password2Property = DependencyProperty.Register("Password2", typeof(string), typeof(LoginController), new PropertyMetadata(null));
            LoginProperty = DependencyProperty.Register("Login", typeof(string), typeof(LoginController), new PropertyMetadata(null));
            PasswordBox2Property = DependencyProperty.Register("PasswordBox2", typeof(PasswordBox), typeof(LoginController), new PropertyMetadata(null));
            AddUserTrueProperty= DependencyProperty.Register("AddUserTrue", typeof(bool), typeof(LoginController), new PropertyMetadata(null));
            CommandButtonProperty=DependencyProperty.Register("CommandButton", typeof(ICommand), typeof(LoginController), new PropertyMetadata(null));

           StateColorProperty = DependencyProperty.Register("StateColor", typeof(Brush), typeof(LoginController), new PropertyMetadata(null));
           StateTextProperty = DependencyProperty.Register("StateText", typeof(string), typeof(LoginController), new PropertyMetadata(null));
            UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(LoginController), new PropertyMetadata(null));
            // StateRequestProperty = DependencyProperty.Register("StateRequest", typeof(Enums.VariantsofStateReqest), typeof(LoginController), new PropertyMetadata(Enums.VariantsofStateReqest.badresult));
        }

        public PasswordBox PasswordBox
        {
            get { return (PasswordBox) GetValue (PasswordBoxProperty); }

            set { Password = value.Password; SetValue(PasswordBoxProperty, value); }

        }
        public PasswordBox PasswordBox2
        {
            get { return (PasswordBox)GetValue(PasswordBox2Property); }

            set {  SetValue(PasswordBox2Property, value); }

        }

        public string Login
        {
            get { return (string)GetValue(LoginProperty); }

            set { SetValue(LoginProperty, value); }

        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }

            set { SetValue(PasswordProperty, value);  }

        }
        public string Password2
        {
            get { return (string)GetValue(Password2Property); }

            set { SetValue(Password2Property, value);
            }

        }

        public bool AddUserTrue
        {
            get { return (bool)GetValue(AddUserTrueProperty); }

            set { SetValue(AddUserTrueProperty, value); }

        }


        public ICommand CommandButton
        {
            get { return (ICommand)GetValue(CommandButtonProperty); }

            set { SetValue(CommandButtonProperty, value); }

        }

        public Brush StateColor
        {
            get
            {
               return (Brush)GetValue(StateColorProperty);
            }

            set
            {
                
                SetValue(StateColorProperty, value);
            }

        }

        
        public string StateText
        {
            get {

                 return(string)GetValue(StateTextProperty);
            }

            set
            {
                SetValue(StateTextProperty, value); }
            }

       public string UserName
        {
            get
            {

                return (string)GetValue(UserNameProperty);
            }

            set
            {
                SetValue(UserNameProperty, value);
            }

        }





        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = (sender as PasswordBox).Password;
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            Password2 = (sender as PasswordBox).Password;
        }

        
    }
}
