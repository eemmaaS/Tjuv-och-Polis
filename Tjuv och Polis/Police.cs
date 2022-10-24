namespace Tjuv_och_Polis
{
    internal class Police : Person
    {

        public Police(int positionX, int positionY, int moveX, int moveY, string activity, bool new_activity) : base(positionX, positionY, moveX, moveY, activity, new_activity)
        {

        }
        public override char Marker => 'P';

        public Person Interact(Person person, List<Person> people, List<Person> prisoners, int indexi, int indexj)
        {
            if (person is Thief)
            {
                if (person.Inventory.Count > 0)
                {
                    int jailtime = person.Inventory.Count;
                    this.Inventory.AddRange(person.Inventory);
                    person.Inventory.Clear();
                    prisoners.Add(person);
                    people.Remove(person);
                    person.PositionX = 0;           //resettar tjuvens position till uppe i högra hörnet
                    person.PositionY = 0;
                    Activity = "Nu skickade persons["+indexj+"](polis) persons["+ indexi+"](tjuv) till fängelset";
                    New_activity = true;
                    ((Thief)person).InJail = true;          //cast
                    ((Thief)person).TimeLeftInJail = jailtime * 100;
                }
            }
            return person;
        }


    }
}
