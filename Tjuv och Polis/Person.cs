using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Person 
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public List<string> Inventory { get; set; } = new List<string>();

        public virtual char Marker { get; set; }

        public virtual void Interact()
        {

        }
    }
}
