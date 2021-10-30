using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class Place
    {
        public string name;
        public string type;
        public string description;

        public Place(string name, string type, string description)
        {
            this.name = name;
            this.type = type;
            this.description = description;
        }
        public override string ToString()
        {
            return name + " (" + type + ")";
        }
    }
}
