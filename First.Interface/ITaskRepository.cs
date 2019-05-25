using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Interface
{
   public interface ITaskRepository
    {

        void AddTask(IMyTask task);

        void SaveInJson(IMyTask task);

        IMyTask ReadTask(string name);

        bool SearchTaskOfName(string name);

        //MyTask DeserializeTask(string path);

        List<IMyTask> ReadAllTasks();

        bool DeleteTask(string name);
    }
}
