namespace Tjuv_och_Polis
{
    internal class Thief : Person
    {

        public Thief(int positionX, int positionY, int moveX, int moveY, string activity, bool new_activity, int time_in_jail, bool inJail) : base(positionX, positionY, moveX, moveY, activity, new_activity)
        {
            TimeLeftInJail = time_in_jail;
            InJail = inJail;
        }
        public override char Marker => 'T';


        public int TimeLeftInJail { get; set; }
        public bool InJail { get; set; }

        public bool New_activity { get; set; }



        public override Person Interact(Person person, int indexi, int indexj)
        {
            if (person is Citizen)
            {
                if (person.Inventory.Count > 0)
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
