using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace First.Interface
{
   public interface INavigationService
    {
            Page First { get; set; }
            Page Second { get; set; }
            Page Third { get; set; }
    }
}
