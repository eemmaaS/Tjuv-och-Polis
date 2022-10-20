using System.Diagnostics;

namespace Tjuv_och_Polis
{
    internal class Thief : Person
    {
        public Thief(int positionX, int positionY, int moveX, int moveY, string activity, bool new_activity) : base(positionX, positionY, moveX, moveY, activity, new_activity)
        {

        }
        public override char Marker => 'T';

        public override Person Interact(Person person, int indexi, int indexj)
        {
            if (person is Citizen)
            {
                if(person.Inventory.Count > 0)
                {
                    Random random = new Random();
                    int rnd = random.Next(0, person.Inventory.Count - 1);
                    string stolen_object = person.Inventory[rnd].ToString();
                    this.Inventory.Add(person.Inventory[rnd]);
                    person.Inventory.RemoveAt(rnd);
                    Activity = "Personindex (Thief) " + indexi + " has stolen " + stolen_object + " from personindex (Citizen) " + indexj;
                    New_activity = true;


                }
                

            }
            return person;
        }
    }
}
