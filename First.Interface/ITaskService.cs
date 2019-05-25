﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace First.Interface
{
    public  interface ITaskService<T>
    {
       
        void DelTask(IMyTask task);

        void AddTask(IMyTask Vmodel);

        List<IMyTask> ReadAllTasks();

        void EditTask(IMyTask myTask);

    }
}
