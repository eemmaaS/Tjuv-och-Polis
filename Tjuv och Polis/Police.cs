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
                if(person.Inventory.Count >= 1)
                {
                    this.Inventory.AddRange(person.Inventory); //tar tjuvens saker och lägger dem i sin egen inventory
                    person.Inventory.Clear(); //tömmer tjuvens inventory
                    Console.WriteLine("Personindex (Thief) " + indexi + " had their loot taken from person Personindex (Police) " + indexj);
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Personindex (Thief) " + indexi + " was inspected by personindex (Police) " + indexj);
                    Thread.Sleep(2000);
                }
                Console.WriteLine(" ");
                Console.WriteLine("Thief inventory: ");

                foreach (Thing thing in person.Inventory)
                {
                    Console.WriteLine(thing);
                }

                Console.WriteLine(" ");
                Console.WriteLine("Police inventory: ");

                foreach (Thing thing in this.Inventory)
                {
                    Console.WriteLine(thing);
                }
                Console.ReadKey();
            }
            return person;
        }
        
    }
}
