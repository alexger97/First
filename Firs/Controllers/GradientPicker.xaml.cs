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
    // [ToDo] Форматирование кода здесь особенно странно выглядит. Нужны ли закомментированные куски кода?
    // Urgency и Importance здесь ломают универсальность элемента управления.
    // Предлагается сделать его более универсальным за счёт переноса расчёта важности и срочности из контрола в
    // view model. Здесь этой логике явно не место. Контрол будет полезен, если его можно будет использовать 
    // для указания на координатной плоскости точки для любых систем из двух координат, не только для
    // важности и сложности, как в данном случае. Также предлагается сделать возможным задание параметров градиента
    // и надписей в коде, использующем данный контрол.

    // [ToDo] Также непонятно, почему папка, в которой лежит контрол называется Controllers. Более логичным было 
    // бы название Controls

    /// <summary>
    /// Логика взаимодействия для GradientPicker.xaml
    /// </summary>
    public partial class GradientPicker :UserControl
    {
        public GradientPicker()
        {
            this.InitializeComponent();
            BrushMy = (Brush)System.ComponentModel.TypeDescriptor
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

        public static DependencyProperty BrushMyProperty;



   

      



        static GradientPicker()
        {
            BrushMyProperty = DependencyProperty.Register("BrushMy", typeof(Brush), typeof(GradientPicker), new PropertyMetadata(null));
            XProperty = DependencyProperty.Register("X", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));
           YProperty = DependencyProperty.Register("Y", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));
           Y_TitleProperty = DependencyProperty.Register("Y_Title", typeof(string), typeof(GradientPicker), new PropertyMetadata(null));
            X_TitleProperty = DependencyProperty.Register("X_Title", typeof(string), typeof(GradientPicker), new PropertyMetadata(null));
            

        //  var metadata1=  new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
            UrgencyProperty = DependencyProperty.Register("Urgency", typeof(bool), typeof(GradientPicker), new PropertyMetadata(null));
            ImportanceProperty = DependencyProperty.Register("Importance", typeof(bool), typeof(GradientPicker), new PropertyMetadata(null));
        }


      




        public Brush BrushMy
        {
            get
            {
                return (Brush)GetValue(BrushMyProperty);
            }

            set
            {
                SetValue(BrushMyProperty, value);

            }
    }

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
            {//OnPropertyChanged("Urgency");
                //_urgency = value;
               SetValue(UrgencyProperty, value);
                //OnPropertyChanged("UrgencyPropery");
              //  OnPropertyChanged("Urgency");
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
              // OnPropertyChanged("Importance");
            }

        }



        private void grid_PointerMoved(object sender, MouseEventArgs e)
        {
            if (check==false)
            {
                BrushMy = (Brush)System.ComponentModel.TypeDescriptor
          .GetConverter(typeof(Brush)).ConvertFromInvariantString("Aqua");
                mousePosition = GetCoordinates(sender, e);
                X = mousePosition.X;
                Y = mousePosition.Y;

                // round. = mousePosition;
            }
        }

        private void grid_PointerPressed(object sender, MouseEventArgs e)
        {



            BrushMy  = (Brush)System.ComponentModel.TypeDescriptor
            .GetConverter(typeof(Brush)).ConvertFromInvariantString("Red");

                Point point = GetCoordinates(sender, e);
                X = point.X;
                Y = point.Y;

                if (Y >= 150)
                { Importance = false; 
                }
                else { Importance = true;
                }

                if (X >= 150)
                { Urgency = true; 
                }
                else { Urgency = false; 
                }

             

                check = !check; //}
                                //  Ellipse.Colo


            

        }
   
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

