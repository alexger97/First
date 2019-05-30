using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First.Interface;

namespace First.Model
{
    public class MyTask: IMyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Importance { get; set; }
        public bool Urgency { get; set; }

       // public IUser TaskUser { get; set; }
        public int UserId { get; set; }

        public MyTask (string Name, string Description, bool Importance, bool Urgency)
        {
            this.Name = Name;
            this.Description = Description;
            this.Importance = Importance;
            this.Urgency = Urgency;

        }

        public MyTask() { }
    }
}
