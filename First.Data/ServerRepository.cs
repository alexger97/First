using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using First.Interface;
using First.Model;


namespace First.Data
{
  public  class ServerRepository: IServerRepository
    {
        //string adress;
        static HttpClient client = new HttpClient();

      public  ServerRepository  ()
        {

           //this.adress = adress;
            //https://localhost:44301/api/Task/
            //client.BaseAddress = new Uri("https://localhost:44301/api/Task");
        }

       
       public   List<IMyTask> ReadAllTasks()
        {
            Task<HttpResponseMessage> task= client.GetAsync(new Uri($"https://localhost:44301/api/Task/GetAllTasks"));
            task.Wait();
            if (task.Result.IsSuccessStatusCode)
            {
                Task<List<MyTask>> myTasks = task.Result.Content.ReadAsAsync<List<MyTask>>();
                myTasks.Wait();
                var yy = myTasks.Result;
                List<IMyTask> oop = new List<IMyTask>();
                foreach(var tt in yy)
                {
                    oop.Add(tt);
                }
                return  oop;
            }

            else return null;
   
        }



        public  async void SendTask(IMyTask task)
        {
            try
            {
                 HttpResponseMessage response = await client.PostAsJsonAsync(new Uri("https://localhost:44301/api/Task"), task);
                 response.EnsureSuccessStatusCode();
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public  async void EditTask (IMyTask myTask)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(new Uri("https://localhost:44301/api/Task"), myTask);
                            response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     

        public  async void DeleteTask(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(new Uri($"https://localhost:44301/api/Task/{id}"));
            response.EnsureSuccessStatusCode();
        }


    }
}
