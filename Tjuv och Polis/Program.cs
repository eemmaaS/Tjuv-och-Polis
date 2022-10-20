using System.Diagnostics;
using System.Text;

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
            
            persons = Methods.Generate(persons);
            Console.CursorVisible = false;
            while (true)
            {
                string[,] city = new string[25, 100];
                string[,] prison = new string[10, 10];

                foreach (Person person in persons)
                {
                    city[person.PositionY, person.PositionX] = person.Marker.ToString();
                    
                }

                foreach (Person person in prisoners)
                {
                    prison[person.PositionY, person.PositionX] = person.Marker.ToString();
                }

                Methods.Draw(city);
                Methods.Draw(prison);
                Methods.Compare(persons, prisoners);
                foreach (Person person in persons)
                { 
                    if(person.New_activity == true)
                    {
                        Activity.Add(person.Activity);
                        person.New_activity = false;
                    }
                }
                foreach(string activity in Activity)
                {
                    Console.WriteLine(activity);
                }
                
                persons = Methods.Move(persons, city);
                prisoners = Methods.Move(prisoners, prison);
                Thread.Sleep(200);
                Console.SetCursorPosition(0, 0);

            }

        }
    }
}