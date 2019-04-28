using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace First.Interface
{
  public  interface IMainViewModel
    {
        // [ToDo] В слое view model не должно быть никаких ссылок на слой View.
        // Здесь не должно присутствовать слово Page или что-либо подобное.
        // 
        Page Main { get; set; }
       Page OneTask1 { get; set; }
         Page ListTasks { get; set; }

        Page CurrentPage { get; set; }

        IOneTaskViewModel OneTaskViewModel { get; set; }
        ISeeListViewModel SeeListViewModel { get; set; }

        Brush ColorButton1
        { get; set; }
        Brush ColorButton2
        { get; set; }

        Brush ColorButton3 { get; set; }


  
      double FrameOpacity { get; set; }
      //  RelayCommand CliclOne { get; set; }
     //  RelayCommand CliclTwo
 void SlowOpacity(Page page);
    }
}
