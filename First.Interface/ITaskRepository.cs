using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Interface
{
   public interface ITaskRepository
    {

        void AddTask(ITask task);

        void SaveInJson(ITask task);

         ITask ReadTask(string name);

         bool SearchTaskOfName(string name);

        ITask DeserializeTask(string path);
    }
}
