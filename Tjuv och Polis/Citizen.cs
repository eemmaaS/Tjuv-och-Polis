using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Citizen : Person
    {
        public Citizen()
        {
            this.Inventory.Add("Nycklar");
            this.Inventory.Add("Plånbok");
            this.Inventory.Add("Mobiltelefon");
            this.Inventory.Add("Klocka");
        }
        public override char Marker => 'M';

        public override void Interact()
        {

        }
    }
}
