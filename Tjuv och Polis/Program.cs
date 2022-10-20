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
                
                Methods.Draw(city);
                Methods.Draw(prison);
                Methods.Compare(persons, prisoners);
                foreach (Person person in persons)
                {
                    if (person.New_activity == true)
                    {
                        Activity.Add(person.Activity);
                        person.New_activity = false;
                    }
                }
                foreach (string activity in Activity)
                {
                    Console.WriteLine(activity);
                }

                Console.WriteLine("There are currently " + prisoners.Count + " thieves in prison");
                persons = Methods.Move(persons, city);
                prisoners = Methods.Move(prisoners, prison);
                Thread.Sleep(200);
                Console.SetCursorPosition(0, 0);

            }

        }
    }
}