namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            List<Person> persons = new List<Person>();
            List<Person> prisoners = new List<Person>();
            persons = Methods.Generate(persons);
            Console.CursorVisible = false;
            while (true)
            {
                string[,] city = new string[25, 100];
                string[,] prison = new string[25, 100];

                foreach (Person person in persons)
                {
                    city[person.PositionY, person.PositionX] = person.Marker.ToString();
                }

                foreach (Person person in prisoners)
                {
                    city[person.PositionY, person.PositionX] = person.Marker.ToString();
                }

                Methods.Draw(city);
                Methods.Draw(prison, city.GetLength(1) + 5);
                Methods.Compare(persons, prisoners);
                persons = Methods.Move(persons, city);
                Thread.Sleep(200);
                Console.SetCursorPosition(0, 0);
            }

        }
    }
}