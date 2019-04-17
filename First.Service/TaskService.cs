using System;
using First.Service;
using First.Data;
using First.Interface;
using System.IO;
using System.Collections.Generic;
using System.Windows;

namespace First.Service
{
    public class TaskService : ITaskService
    {
        static ITaskRepository taskRepository;

        public TaskService(ITaskRepository repository)
        {

       taskRepository = repository;
           
      }

       public void DelTask(string name)
        {
            if (!taskRepository.DeleteTask(name))
            { MessageBox.Show("Удаление не удалось"); }

            else { MessageBox.Show("Удаление удалось"); }
            

        }
 

        public  void AddTaskService(IMyTask Vmodel)
        {
            taskRepository.AddTask(Vmodel);
        }

        public  IMyTask GetTask(string name)
        {

            var _task = taskRepository.ReadTask(name);
      
            if (_task != null) { MessageBox.Show("Задача найдена"); return _task; }
            else { MessageBox.Show("Задача  не найдена"); return null; }

        }

        public  List<IMyTask> ReadAllTasks()
        {
           
            return taskRepository.ReadAllTasks();
            


        }
       


      


    }
}
