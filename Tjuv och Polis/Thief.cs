using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Thief : Person
    {
        public Thief(int positionX, int positionY, int moveX, int moveY) : base(positionX, positionY, moveX, moveY)
        {

        }
        public override char Marker => 'T';

        public override Person Interact(Person person, int indexi, int indexj)
        {
            if(person is Citizen)
            {
                if (person.Inventory != null && person.Inventory.Count > 0)
                {
                    Random random = new Random();
                    int rnd = random.Next(0, person.Inventory.Count - 1);
                    string stolen_object = person.Inventory[rnd].ToString();
                    this.Inventory.Add(person.Inventory[rnd]);
                    person.Inventory.RemoveAt(rnd);
                    Console.Write("Thief " + indexi + " has stolen " + stolen_object + " from  citizen " + indexj);
                    Console.ReadKey();
                }
               
                   


            }
            return person;
        }
    }
}
