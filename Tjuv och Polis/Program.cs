namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons = Methods.Generate(persons);
            Console.CursorVisible = false;
            while (true)
            {
                string[,] city = new string[25, 100];
                foreach (Person person in persons)
                {
                    city[person.PositionY, person.PositionX] = person.Marker.ToString();
                }
                Methods.Draw(city);
                Methods.Compare(persons);
                persons = Methods.Move(persons, city);
                Thread.Sleep(200);
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}