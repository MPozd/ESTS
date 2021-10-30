using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class CurrSession
    {
        public User curruser;
        public Rights user;
        public Rights employee;
        public Factory factory;


        static Lazy<CurrSession> mySession = new Lazy<CurrSession>(() => new CurrSession());
        
        public static CurrSession MySession
        {
            get
            {
                return mySession.Value;
            }
        }

        public CurrSession()
        {
            this.user = new Rights("user");
            this.employee = new Rights("employee");
            this.factory = new Factory();
        }
        public User SetUser()
        {
            User u = new User(this.user);
            this.curruser = u;
            return u;
        }
        public User SetUser(string name, string password)
        {
            User u = new Employee(name, this.employee, password);
            this.curruser = u;
            return u;
        }
        
    }
}
