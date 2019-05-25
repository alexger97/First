using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Interface
{
   public interface IOneTaskViewModel
    {




    IMainViewModel MainWindowViewModel { get; set; }

    IMyTask ActualTask { get;set; }
       
    bool ImportanceVM { get; set; }
    
    bool UrgencyVM { get; set; }
      
    string Name { get; set; }
        
    string Description { get; set; }





       


    }
}
