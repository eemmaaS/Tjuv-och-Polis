namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();         
            persons = Methods.Generate(persons);

            while (true)
            {
                string[,] city = new string[25, 100];
                foreach (Person person in persons)
                {
                    city[person.PositionY, person.PositionX] = person.Marker.ToString();
                }
                Methods.Draw(city);
                persons = Methods.Move(persons, city);
                Thread.Sleep(200);
                Console.Clear();               
            }
                   
            Console.ReadKey();
            //testet
            //test1234
        }
    }
}