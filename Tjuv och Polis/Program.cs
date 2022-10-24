using System.Diagnostics;

namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> Activity = new List<string>();
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            List<Person> persons = new List<Person>();
            List<Person> prisoners = new List<Person>();
            string[,] city = new string[25, 100];
            string[,] prison = new string[10, 10];
            persons = Methods.Generate(persons);
            Console.CursorVisible = false;         
            while (true)
            {
                Methods.Updatepositions(city, prison, persons, prisoners);
                Methods.Draw(city);
                Methods.Draw(prison, city.GetLength(1) + 5);
                Methods.Compare(persons, prisoners);
                Methods.CheckActivity(persons, Activity);
                Methods.PrintActivity(Activity, city); 
                persons = Methods.Move(persons, city);
                prisoners = Methods.Move(prisoners, prison);                
                Methods.PrintPrisonStatus(prisoners,prison,city);
                
            }

        }
       


        }
    }