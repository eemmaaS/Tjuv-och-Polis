namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string[,] city = new string[25, 100];            
            persons = Methods.Generate(persons);

            while (true)
            {
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