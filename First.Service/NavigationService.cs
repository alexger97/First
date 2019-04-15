using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using First.Interface;

namespace First.Service
{
  public  class NavigationService
    {
        private Frame frame;

        public bool Navigate(Page page, IViewModel vm)
        {
          // if (parametr !=null)
            page.DataContext = vm;
            Type type = page.GetType();
            return frame.Navigate(page);
        }
    }
}
