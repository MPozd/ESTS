using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class User
    {
        public string name;
        public Rights rights;
        public User(Rights rights)
        {
            this.rights = rights;
            this.name = "Гость";
        }
    }

    class Employee : User
    {
        public string password;
        public Employee(string name, Rights rights, string password) : base(rights)
        {
            this.name = name;
            this.rights = rights;
            this.password = password;
        }

    }
}
