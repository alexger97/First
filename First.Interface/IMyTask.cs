﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Interface
{
   public interface IMyTask
    {

        string Name { get; set; }
        string Description { get; set; }
        bool Importance { get; set; }
         bool Urgency { get; set; }
       
    }
}
