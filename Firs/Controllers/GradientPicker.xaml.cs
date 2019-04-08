using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace First.Controllers
{
    /// <summary>
    /// Логика взаимодействия для GradientPicker.xaml
    /// </summary>
    public partial class GradientPicker :UserControl // INotifyPropertyChanged
    {
        public GradientPicker()
        {
            this.InitializeComponent();
            this.DataContext = this;
            round.Fill = (Brush)System.ComponentModel.TypeDescriptor
          .GetConverter(typeof(Brush)).ConvertFromInvariantString("Aqua");
            Y_Title = "First";
            X_Title = "Second";
        }
        private Point mousePosition;
        private bool check = false;


        public static readonly DependencyProperty XProperty;
        public static readonly DependencyProperty YProperty;
        public static readonly DependencyProperty X_TitleProperty;
       public static readonly DependencyProperty Y_TitleProperty;



       public static  DependencyProperty UrgencyProperty;
       public static  DependencyProperty ImportanceProperty;

      //  public event PropertyChangedEventHandler PropertyChanged;
      //  public virtual void OnPropertyChanged(string propertyName)
       /// {
        //    PropertyChangedEventHandler handler = this.PropertyChanged;
         //   if (handler != null)
          //  {
          //      handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
          //  }
       // }


            static GradientPicker()
        {
            XProperty = DependencyProperty.Register("X", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));
           YProperty = DependencyProperty.Register("Y", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));
           Y_TitleProperty = DependencyProperty.Register("Y_Title", typeof(string), typeof(GradientPicker), new PropertyMetadata(null));
            X_TitleProperty = DependencyProperty.Register("X_Title", typeof(string), typeof(GradientPicker), new PropertyMetadata(null));


           UrgencyProperty = DependencyProperty.Register("Urgency", typeof(bool), typeof(GradientPicker), new PropertyMetadata(null));
            ImportanceProperty = DependencyProperty.Register("Importance", typeof(bool), typeof(GradientPicker), new PropertyMetadata(null));
        }

      // private double _x;
      //  private double _y;
        //private string _x_title;
       // private string y_title;
       
       // private bool _urgency;

      // private bool _importance;

        public double X
        {
            get
            {
               // return _x;
               return (double)GetValue(XProperty);
            }
            set
            {
                  SetValue(XProperty, value);
               // _x = value;
                //OnPropertyChanged("X");
            }
        }
        public double Y
        {
            get
            {
                //return _y;
               return (double)GetValue(YProperty);
            }
            set
            {
               // _y = value;
                   SetValue(YProperty, value);
               // OnPropertyChanged("Y");
            }
        }
        public string X_Title
        {
            get
            {
              ///  return _x_title;
                 return (string)GetValue(X_TitleProperty);
            }
            set
            {
                ///_x_title = value;
               SetValue(X_TitleProperty, value: value);
               /// OnPropertyChanged("X_Title");
            }
        }
        public string Y_Title
        {
            get
            {
                //return y_title;
               return (string)GetValue(Y_TitleProperty);
            }
            set
            {
             //   y_title = value;
                SetValue(Y_TitleProperty, value);
              ////  OnPropertyChanged("Y_Title");
            }
        }

        public bool Urgency
        {
            get => (bool)GetValue(UrgencyProperty);

            set
            {//OnPropertyChanged("Urgency2");
                //_urgency = value;
               SetValue(UrgencyProperty, value);
                //OnPropertyChanged("UrgencyPropery");
                
            }

        }

        public bool Importance
        {
            get =>// _importance;
                (bool)GetValue(ImportanceProperty);

            set
            {
               // _importance = value;
                SetValue(ImportanceProperty, value);
               // OnPropertyChanged("Importance2");
            }

        }


        private static void ImportanceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          //  TextBox control = d as TextControl;
          //  if (e.Property == TextProperty)
          //  {
           //     control.Text = e.NewValue.ToString();
           //     return;
           // }

        }

        private void grid_PointerMoved(object sender, MouseEventArgs e)
        {
            if (check==false)
            {
                round.Fill = (Brush)System.ComponentModel.TypeDescriptor
        .GetConverter(typeof(Brush)).ConvertFromInvariantString("Aqua");
                mousePosition = GetCoordinates(sender, e);
                round.DataContext = mousePosition;
            }
        }

        private void grid_PointerPressed(object sender, MouseEventArgs e)
        {
           
          

                round.Fill = (Brush)System.ComponentModel.TypeDescriptor
            .GetConverter(typeof(Brush)).ConvertFromInvariantString("Red");

                Point point = GetCoordinates(sender, e);
                X = point.X;
                Y = point.Y;

                if (Y >= 150)
                { Importance = false; //Text_Importance.Text = " Не важно";
                }
                else { Importance = true; //Text_Importance.Text = "Важно";
                }

                if (X >= 150)
                { Urgency = true; //Text_Urgency.Text = "Cрочно";
                }
                else { Urgency = false; //Text_Urgency.Text = "Не срочно";
                }

              //  MessageBox.Show(Urgency2.ToString() + "   " + Importance2.ToString());

                check = !check; //}
            //  Ellipse.Colo

        }
       /* private static void PropertyChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            TextBox control = depObj as TextControl;
            if (e.Property == TextProperty)
            {
                control.Text = e.NewValue.ToString();
                return;
            }
        }*/


        private Point GetCoordinates(object sender, MouseEventArgs e)
        {

            var gr = (Grid)sender;
            Point position = e.GetPosition(gr);
            //Point position = e.GetCurrentPoint(gr).Position;

            if (position.X > gr.Width - round.Width)
            {
                position.X -= round.Width;

                if (position.Y > gr.Height - round.Height)
                {
                    position.Y -= round.Height;
                }

            }
            else if (position.Y > gr.Height - round.Height)
            {
                position.Y -= round.Height;
            }
            return position;
        }

        
    }
}

