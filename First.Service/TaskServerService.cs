using System;
using First.Service;
using First.Data;
using First.Interface;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using First.Model;


namespace First.Service
{
    
    public class TaskServerService : ITaskService<IServerRepository>
    {
      
        static private ServerRepository taskRepository;

        public TaskServerService(IServerRepository _serverData)
        {
            taskRepository = (ServerRepository) _serverData; 
        }

       public void DelTask(IMyTask task)
        {
            taskRepository.DeleteTask(task.Id);
        }
 
       
        public  void AddTask(IMyTask Vmodel)
        {
            taskRepository.SendTask(Vmodel); 
        }


        public void EditTask (IMyTask myTask)
        {
            taskRepository.EditTask(myTask);

        }

        public  List<IMyTask> ReadAllTasks(int id)
        {
            

            return  taskRepository.ReadAllTasks(id);
         
        }


        public IUser LoginUser(object[] auth)
        {

            return taskRepository.LoginUser(auth);
        }

        public IUser AddUser(object[] auth)
        {

            return taskRepository.AddUser(auth);
        }


    }
}
