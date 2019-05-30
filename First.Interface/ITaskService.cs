using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace First.Interface
{
    public  interface ITaskService<T>
    {
        IUser LoginUser(object[] auth);
        IUser AddUser(object[] auth);
        void DelTask(IMyTask task);

        void AddTask(IMyTask Vmodel);

        List<IMyTask> ReadAllTasks(int id);

        void EditTask(IMyTask myTask);

    }
}
