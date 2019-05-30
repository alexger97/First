using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace First.Interface
{
   public interface ISettingsViewModel
    {
       
        bool UseServer { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Password2 { get; set; }
        bool AddUser { get; set; }

        string StateText { get; set; }

        Brush StateColor { get; set; }

    }
}
