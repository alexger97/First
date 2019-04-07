using System;
using First.Service;
using First.Data;
using First.Interface;
using System.IO;

namespace First.Service
{
    public class TaskService:ITaskService
    {
        //  public MyTask newtask = null;
    static    TaskRepository taskRepository = new TaskRepository();

        public static void AddTaskService(Interface.ITask Vmodel)
        {
            taskRepository.AddTask(Vmodel);
        }

        public static Interface.ITask GetTask(string name)
        {

            var _task = taskRepository.ReadTask(name);
            if (_task != null) return _task;
            else return null;

        }

       


        //  public static void OpenWindow()
        //     {
        //      MainWindow2 me=  new MainWindow2

        //   }


    }
}
