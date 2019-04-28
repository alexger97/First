﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Interface
{
 public  interface ITaskService
    {
        void AddTask(IMyTask Vmodel);


        IMyTask GetTask(string name);

        void DelTask(string name);
        List<IMyTask> ReadAllTasks();
      
    }
}
