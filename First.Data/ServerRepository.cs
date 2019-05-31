using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using First.Interface;
using First.Model;
using System.Net.Http.Formatting;

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

       
       public   List<IMyTask> ReadAllTasks(int id)
        {
            Task<HttpResponseMessage> task = client.GetAsync(new Uri($"https://taskserverapp3.azurewebsites.net/api/Task/GetAllTasks/{id}"));
                                                                          // $"https://taskserverapp20190526040022.azurewebsites.net/api/Task/GetAllTasks";
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
        //https://taskserverapp20190526040022.azurewebsites.net/api/Task/


        public  async void SendTask(IMyTask task)
        {
            try
            {
                 HttpResponseMessage response = await client.PostAsJsonAsync(new Uri("https://taskserverapp3.azurewebsites.net/api/Task/"), task);;
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
                HttpResponseMessage response = await client.PutAsJsonAsync(new Uri("https://taskserverapp3.azurewebsites.net/api/Task/"), myTask);
                            response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       // https://localhost:44301/api

        public  async void DeleteTask(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(new Uri($"https://taskserverapp3.azurewebsites.net/api/Task/{id}"));
            response.EnsureSuccessStatusCode();
        }


        public IUser LoginUser(object[] auth)
        {

            Task<HttpResponseMessage> response =  client.PostAsJsonAsync(new Uri("https://taskserverapp3.azurewebsites.net/api/User/LoginUser"), auth);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var yy = response.Result.Content.ReadAsAsync<User>();
                yy.Wait();
                return (IUser) yy.Result;
            }

            return null;

        }

        public IUser AddUser(object[] auth)
        {

            Task<HttpResponseMessage> response = client.PostAsJsonAsync(new Uri("https://taskserverapp3.azurewebsites.net/api/User/AddUser"), auth);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                var yy = response.Result.Content.ReadAsAsync<User>();
                yy.Wait();
                return (IUser)yy.Result;
            }

            return null;

        }



    }
}
