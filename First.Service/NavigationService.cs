using First.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace First.Service
{
    public   class NavigationService: INavigationService
    {
        public IView First { get; set; }
        public IView Second { get; set; }
        public IView Third  { get; set; }


    }
}
