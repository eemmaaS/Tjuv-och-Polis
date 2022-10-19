namespace Tjuv_och_Polis
{
    internal class Police : Person
    {
        public Police(int positionX, int positionY, int moveX, int moveY) : base(positionX, positionY, moveX, moveY)
        {

        }
        public override char Marker => 'P';

        public Person Interact(Person person, List<Person> people, List<Person> prisoners, int indexi, int indexj)
        {
            if (person is Thief)
            {
                if (person.Inventory != null)
                {
                    this.Inventory.AddRange(person.Inventory);
                    person.Inventory.Clear();
                    prisoners.Add(person);
                    people.Remove(person);
                    Console.SetCursorPosition(0, 30);
                    Console.WriteLine("Nu åkte en i fängelse");
                }
            }
            return person;
        }
    }
}
