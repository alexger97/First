using First.Controllers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace First
{
    /// <summary>
    
    /// </summary>
    public partial class OneTask :Page
    {
        public OneTask(IMyTask myTask, ViewModelBase viewModelBase)
        {
            //   this.DataContext=
            //  Binding binding = new Binding();
            // binding.Path= new PropertyPath()
            //  binding.ElementName = "tt"; // элемент-источник
            //  binding.Path = new PropertyPath("DataContext"); // свойство элемента-источника
            //this.DataContext.SetBinding(this.DataContext, binding); // установка привязки для элемента-приемника
            // DatConst = new OneTaskViewModel(myTask, viewModelBase);

           // DatConst = viewModelBase;
          // binding.Source = DatConst;
          InitializeComponent();
            DatConst = new OneTaskViewModel(myTask, viewModelBase);
            this.DataContext = DatConst;
            ct.DataContext = DatConst;
        }
      public ViewModelBase DatConst ;
    }
}


  