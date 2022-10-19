using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Thing
    {
        public Thing(string name)
        {
            Name = name;
        }

            string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

}
