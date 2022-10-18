namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string[,] city = new string[25, 100];            
            persons = Methods.Generate(persons);
            Methods.Draw(city);

            Console.ReadKey();
            //testet
            //test1234
        }
    }
}