using First.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Model
{
    public class User : IUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
