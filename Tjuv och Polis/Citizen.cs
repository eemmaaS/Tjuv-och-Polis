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
        public Citizen(int positionX, int positionY, int moveX, int moveY) : base(positionX, positionY, moveX, moveY)
        {
            this.Inventory.Add(new Thing("Nycklar"));
            this.Inventory.Add(new Thing("Plånbok"));
            this.Inventory.Add(new Thing("Mobiltelefon"));
            this.Inventory.Add(new Thing("Klocka"));
        }
        public override char Marker => 'M';

        public override void Interact()
        {

        }
    }
}
