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
            persons = Methods.Generate(persons);
            Console.CursorVisible = false;
            string[,] city = new string[25, 100];
            string[,] prison = new string[10, 10];
            while (true)
            {
                Methods.Draw(city);
                Methods.Draw(prison, city.GetLength(1) + 5);
                Methods.Compare(persons, prisoners);
                CheckActivity(persons, Activity);
                PrintActivity(Activity);
                Updatepositions(city,prison,persons,prisoners);
                PrintPrisonStatus(prisoners,prison,city);
                persons = Methods.Move(persons, city);
                prisoners = Methods.Move(prisoners, prison);
                

            }

        }
        static void CheckActivity(List<Person> persons, List<string> activity)
        {
            foreach (Person person in persons)
            {
                if (person.New_activity == true)
                {
                    activity.Add(person.Activity);
                    person.New_activity = false;
                }
            }

        }

        static void PrintPrisonStatus(List<Person> prisoners, string[,] prison, string[,] city)
        { 
            Console.SetCursorPosition(prison.GetLength(0) + 3, city.GetLength(1) + 1);
            Console.WriteLine("There are currently " + prisoners.Count + " thief/thieves in prison");
            Console.SetCursorPosition(0, 0);
        }
        static void PrintActivity(List<string> activity)
        {
            for (int i = 0; i < activity.Count; i++)
            {
                Console.SetCursorPosition(26, 0);
                Console.WriteLine(activity[i]);
                Console.SetCursorPosition(0, 0);
            }
            if (activity.Count > 10)
            {
                activity.Clear();
                Console.Clear();
            }
        }

            static void Updatepositions(string[,] city, string[,] prison, List<Person> persons, List<Person> prisoners)
            {
                foreach (Person person in persons)
                {
                    city[person.PositionY, person.PositionX] = person.Marker.ToString();
                }
                foreach (Person thief in prisoners)
                {
                    prison[thief.PositionY, thief.PositionX] = thief.Marker.ToString();
                }

                for (int i = 0; i < prisoners.Count; i++)
                {
                    ((Thief)prisoners[i]).TimeLeftInJail = ((Thief)prisoners[i]).TimeLeftInJail - 1;
                    if (((Thief)prisoners[i]).TimeLeftInJail == 0)
                    {
                        ((Thief)prisoners[i]).InJail = false;
                        {
                            persons.Add(prisoners[i]);
                            prisoners.Remove(prisoners[i]);
                            //var previousCursor = Console.GetCursorPosition();
                            //Console.SetCursorPosition(50, 50);
                            //Console.WriteLine("A prisoner has left the jail!");
                            //Thread.Sleep(200);
                            //Console.SetCursorPosition(50, 50);
                            //Console.WriteLine("");
                            //Console.SetCursorPosition(previousCursor.Left, previousCursor.Top);
                            break;
                        }
                    }
                }
            }


        }
    }