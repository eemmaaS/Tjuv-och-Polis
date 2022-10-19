using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Police : Person
    {
        public Police(int positionX, int positionY, int moveX, int moveY) : base(positionX, positionY, moveX, moveY)
        {

        }
        public override char Marker => 'P';

        public override Person Interact(Person person, int indexi, int indexj)
        {
            if (person is Thief)
            {
                if(person.Inventory != null)
                {
                    this.Inventory.AddRange(person.Inventory);
                    person.Inventory.Clear();
                }
            }
            return person;
        }
    }
}
