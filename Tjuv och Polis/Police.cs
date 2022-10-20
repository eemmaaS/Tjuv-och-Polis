namespace Tjuv_och_Polis
{
    internal class Police : Person
    {

        public Police(int positionX, int positionY, int moveX, int moveY, string activity, bool new_activity) : base(positionX, positionY, moveX, moveY, activity, new_activity)
        {

        }
        public override char Marker => 'P';

        public Person  Interact(Person person, List<Person> people, List<Person> prisoners, int indexi, int indexj)
        {
            if (person is Thief)
            {
                if (person.Inventory.Count > 0)
                {
                    this.Inventory.AddRange(person.Inventory);
                    person.Inventory.Clear();
                    prisoners.Add(person);
                    people.Remove(person);
                    person.PositionX = 0;
                    person.PositionY = 0;
                    Console.SetCursorPosition(0, 39);
                    Activity = "Nu skickade person " + indexj+ " (polis) person " + indexi + " (tjuv) till fängelset";
                    New_activity = true;
                   
                    


                }
            }
            return person;
        }

      
    }
}
