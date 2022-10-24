namespace Tjuv_och_Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); //bestämmer hur stort programfönstret är
            Console.CursorVisible = false;
            List<string> Activity = new List<string>();
            List<Person> persons = new List<Person>();
            List<Person> prisoners = new List<Person>();
            persons = Methods.Generate(persons);
          
            while (true)
            {
                string[,] city = new string[15, 160];
                string[,] prison = new string[5, 20];

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
                            break;                            
                            }
                        }
                    }
                
                Methods.Draw(city);
                Methods.Draw(prison);
                Methods.Compare(persons, prisoners);
                foreach (Person person in persons)   //om boolen är true så lagras en aktivitet
                {
                    if (person.New_activity == true)
                    {       
                        Activity.Add(person.Activity);
                        person.New_activity = false;
                    }
                }

                for ( int i = 0; i < Activity.Count; i++)
                {
                    Console.WriteLine(Activity[i]);
                }
                if (Activity.Count >= 15)
                {
                    Activity.Clear();
                    Thread.Sleep(200);
                    Console.Clear();
                }
                Console.WriteLine("Det är " + prisoners.Count + " tjuv/tjuvar i fängelset");
                persons = Methods.Move(persons, city);
                prisoners = Methods.Move(prisoners, prison);                              
                Console.SetCursorPosition(0, 0);

            }

        }
    }
}