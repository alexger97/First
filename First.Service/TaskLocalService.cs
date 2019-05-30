using First.Data;
using First.Interface;
using First.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace First.Service
{
   public class TaskLocalService:ITaskService<ITaskRepository>
    {
        static TaskRepository taskRepository;

        public TaskLocalService(ITaskRepository repository)
        {
            taskRepository = (TaskRepository)repository;
        }

        public void DelTask(IMyTask task)
        {
            if (!taskRepository.DeleteTask(task.Name))
            {
                MessageBox.Show("Удаление не удалось");
            }

            else
            {
                MessageBox.Show("Удаление удалось");
            }
        }

        
        public void AddTask(IMyTask Vmodel)
        {
            taskRepository.AddTask(Vmodel);
        }

        public IMyTask GetTask(string name)
        {

            var _task = taskRepository.ReadTask(name);

            if (_task != null) { MessageBox.Show("Задача найдена"); return _task; }
            else { MessageBox.Show("Задача  не найдена"); return null; }

        }

        public List<IMyTask> ReadAllTasks(int id)
        {
            return taskRepository.ReadAllTasks();
        }

 

        public void EditTask(IMyTask myTask)
        {
            AddTask(myTask);
        }

        public IUser LoginUser()
        {
            return (IUser)new User { Id = 0, Name = "Localhost" };
        }

        public IUser LoginUser(object[] auth)
        {
            //throw new NotImplementedException();
            return null;
        }

        public IUser AddUser(object[] auth)
        {
            throw new NotImplementedException();
        }
    }
}
