using First.Interface;
using First.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace First.Data
{
    public class TaskRepository:ITaskRepository
    {

        public void AddTask(IMyTask task)
        {
            SaveInJson(task);
        }


        public void SaveInJson(IMyTask task)
        {
            string json = JsonConvert.SerializeObject(task);
            File.WriteAllText(@"../DataJson/" + task.Name + ".json", json);
           
        }



        public IMyTask ReadTask(string name)
        {
            if (SearchTaskOfName(name))
            {
                var deTask = DeserializeTask(@"../DataJson/" + name + ".json");
                MessageBox.Show("Успешно десириалован+" + deTask.Description);
                return deTask;
            }
            MessageBox.Show("Не найден"); return null;
        }


            // else { MessageBox.Show("Дата таску не нашла"); 
            //   return null;
        

        public List<IMyTask> ReadAllTasks()
        {
            string[] allFoundFiles = Directory.GetFiles(@"../DataJson/", @"*.json", SearchOption.AllDirectories);
            List< IMyTask > tasks = new List<IMyTask>();
            foreach (string path in allFoundFiles)
            {
                IMyTask tsk = DeserializeTask(path);
                if (tsk != null)
                {
                    tasks.Add(tsk);
                }
            }
            return tasks;
        }



        public bool SearchTaskOfName(string name)
        {
            string path = @"../DataJson/" + name + ".json";
           if (File.Exists(path))
                
                return true;
                         return false;
        }


    //    ITask dtask = new TaskRepository().DeserializeTask("");

        public IMyTask DeserializeTask(string path)
        {
            string ss = File.ReadAllText(path);
            var mytask = JsonConvert.DeserializeObject<Model.MyTask>(ss);
            return mytask;


        }

    }
}
