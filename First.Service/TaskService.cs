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
        //  public MyTask newtask = null;

       // public TaskService(ITaskRepository repository)
       // {

            //taskRepository = repository;

        //}

        static ITaskRepository taskRepository= new TaskRepository();
  // public TaskService(ITaskRepository service)
    //       {
        // taskRepository = service;
      //              }

      

        public static void AddTaskService(IMyTask Vmodel)
        {
            taskRepository.AddTask(Vmodel);
        }

        public static IMyTask GetTask(string name)
        {

            var _task = taskRepository.ReadTask(name);
      
            if (_task != null) { MessageBox.Show("Задача найдена"); return _task; }
            else { MessageBox.Show("Задача  не найдена"); return null; }

        }

        public static List<IMyTask> ReadAllTasks()
        {
            MessageBox.Show("!!@#@#");
            return taskRepository.ReadAllTasks();
            


        }
       


        //  public static void OpenWindow()
        //     {
        //      MainWindow2 me=  new MainWindow2

        //   }


    }
}
