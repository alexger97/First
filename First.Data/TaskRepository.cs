using First.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace First.Data
{
    public class TaskRepository:ITaskRepository
    {

        public void AddTask(ITask task)
        {
            SaveInJson(task);
        }


        public void SaveInJson(ITask task)
        {
            string json = JsonConvert.SerializeObject(task); 
            using (StreamWriter file = File.CreateText(@"../DataJson/" + task.Name + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, json);
            }
        }

        public ITask ReadTask(string name)
        {
            if (SearchTaskOfName("1")) return DeserializeTask(File.ReadAllText(@"../DataJson/" + name + ".json"));
            else
                return null;
        }

        public bool SearchTaskOfName(string name)
        {
            try
            {
                DeserializeTask(File.ReadAllText(@"../DataJson/" + name + ".json"));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ITask DeserializeTask(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<ITask>(path);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
