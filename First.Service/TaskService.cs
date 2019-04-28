using System;
using First.Service;
using First.Data;
using First.Interface;
using System.IO;
using System.Collections.Generic;
using System.Windows;

namespace First.Service
{
    // [ToDo] Общая рекоммендация : привести в порядок отступы и структуру кода.
    // Для этого можно использовать любой популярный свод рекоммендаций по оформлению кода. 
    // Главное - его придерживаться во всех неавтосгенерированных файлах проекта.
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
            {
                MessageBox.Show("Удаление не удалось");
            }

            else
            {
                MessageBox.Show("Удаление удалось");
            }
        }
 
        // [ToDo] Неподходящее имя для метода добавления задачи. Мы не добавляем сервис,
        // а добавляем задачу.
        public  void AddTask(IMyTask Vmodel)
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
