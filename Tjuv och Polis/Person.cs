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
        public Person (int positionX, int positionY, int moveX, int moveY)
        {
            PositionX = positionX;
            PositionY = positionY; 
            MoveX = moveX;
            MoveY = moveY;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int MoveX { get; set; }
        public int MoveY { get; set; }


        public List<Thing> Inventory { get; set; } = new List<Thing>();

        public virtual char Marker { get; set; }

        public virtual void Interact()
        {

        }
    }
}
