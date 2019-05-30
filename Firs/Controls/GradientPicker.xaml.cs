using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace First.Controls
{

    public partial class GradientPicker :UserControl
    {
        public GradientPicker()
        {
            this.InitializeComponent();
        }
        private Point mousePosition;
        private bool check = false;


        public static readonly DependencyProperty XProperty;
        public static readonly DependencyProperty YProperty;
        public static readonly DependencyProperty X_TitleProperty;
       public static readonly DependencyProperty Y_TitleProperty;

        public static readonly DependencyProperty XX_Property;
        public static readonly DependencyProperty YY_Property;
        public static  DependencyProperty UrgencyProperty;
       public static  DependencyProperty ImportanceProperty;

        public static DependencyProperty FirstGradientColorProperty;
        public static DependencyProperty SecondGradientColorProperty;
        public static DependencyProperty ThirdGradientColorProperty;

        public static DependencyProperty BrushMyProperty;



   

      



        static GradientPicker()
        {
            BrushMyProperty = DependencyProperty.Register("BrushMy", typeof(Brush), typeof(GradientPicker), new PropertyMetadata(null));
            XProperty = DependencyProperty.Register("X", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));
           YProperty = DependencyProperty.Register("Y", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));
           Y_TitleProperty = DependencyProperty.Register("Y_Title", typeof(string), typeof(GradientPicker), new PropertyMetadata(null));
            X_TitleProperty = DependencyProperty.Register("X_Title", typeof(string), typeof(GradientPicker), new PropertyMetadata(null));
            XX_Property = DependencyProperty.Register("XX", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));
            YY_Property = DependencyProperty.Register("YY", typeof(double), typeof(GradientPicker), new PropertyMetadata(null));

            FirstGradientColorProperty= DependencyProperty.Register("FirstGradientColor", typeof(Color), typeof(GradientPicker), new PropertyMetadata(null));
            SecondGradientColorProperty = DependencyProperty.Register("SecondGradientColor", typeof(Color), typeof(GradientPicker), new PropertyMetadata(null));
            ThirdGradientColorProperty = DependencyProperty.Register("ThirdGradientColor", typeof(Color), typeof(GradientPicker), new PropertyMetadata(null));
        }


      public Color FirstGradientColor
        {
            get { return(Color)GetValue(FirstGradientColorProperty); }

            set { SetValue(FirstGradientColorProperty, value); }
        }

        public Color SecondGradientColor
        {
            get { return (Color)GetValue(SecondGradientColorProperty); }

            set { SetValue(SecondGradientColorProperty, value); }
        }

        public Color ThirdGradientColor
        {
            get { return (Color)GetValue(ThirdGradientColorProperty); }

            set { SetValue(ThirdGradientColorProperty, value); }
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
              
               return (double)GetValue(XProperty);
            }
            set
            {
                  SetValue(XProperty, value);
            
            }
        }

        public double XX
        {
            get
            {

                return (double)GetValue(XX_Property);
            }
            set
            {
                SetValue(XX_Property, value);

            }
        }



        public double Y
        {
            get
            {
               
               return (double)GetValue(YProperty);
            }
            set
            {
             
     SetValue(YProperty, value); 
            }
        }

        public double YY
        {
            get
            {

                return (double)GetValue(YY_Property);
            }
            set
            {

                SetValue(YY_Property, value);
            }
        }




        public string X_Title
        {
            get
            {
                 return (string)GetValue(X_TitleProperty);
            }
            set
            {
               SetValue(X_TitleProperty, value: value);
            }
        }
        public string Y_Title
        {
            get
            {
               return (string)GetValue(Y_TitleProperty);
            }
            set
            {
                SetValue(Y_TitleProperty, value);
            }
        }

        public bool Urgency
        {
            get => (bool)GetValue(UrgencyProperty);

            set
            {
               SetValue(UrgencyProperty, value);
            }

        }

        public bool Importance
        {
            get => (bool)GetValue(ImportanceProperty);

            set
            {
                SetValue(ImportanceProperty, value);
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

               
            }
        }

        private void grid_PointerPressed(object sender, MouseEventArgs e)
        {
          BrushMy  = (Brush)System.ComponentModel.TypeDescriptor
           .GetConverter(typeof(Brush)).ConvertFromInvariantString("Red");

                Point point = GetCoordinates(sender, e);
                X = point.X;
                Y = point.Y;
                YY = Y;
                XX=X;
                check = !check; 
        }
   
        private Point GetCoordinates(object sender, MouseEventArgs e)
        {

            var gr = (Grid)sender;
            Point position = e.GetPosition(gr);

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

