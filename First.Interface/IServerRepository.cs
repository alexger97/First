using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Interface
{
  public  interface IServerRepository
    {
        List<IMyTask> ReadAllTasks(int id);
        IUser AddUser(object[] auth);
        IUser LoginUser(object[] auth);
        void SendTask(IMyTask task);

        void EditTask(IMyTask myTask);

        void DeleteTask(int id);
    }
}
