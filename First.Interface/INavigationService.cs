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
        IView First { get; set; }
        IView Second { get; set; }
        IView Third { get; set; }
    }
}
