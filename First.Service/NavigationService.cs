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
        public  Page First { get; set; }
        public Page Second { get; set; }
        public Page Third  { get; set; }


    }
}
