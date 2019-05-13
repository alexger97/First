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
      

        IView CurrentPage { get; set; }

        IOneTaskViewModel OneTaskViewModel { get; set; }
        ISeeListViewModel SeeListViewModel { get; set; }
        INavigationService NavigationService { get; set; }

        Brush ColorButton1 { get; set; }
        Brush ColorButton2 { get; set; }
        Brush ColorButton3 { get; set; }

        double FrameOpacity { get; set; }
     
        void SlowOpacity(IView page);
    }
}
