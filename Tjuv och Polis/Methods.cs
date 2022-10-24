namespace Tjuv_och_Polis
{
    internal class Methods
    {
        public static List<Person> Move(List<Person> persons, string[,] city)
        {
            foreach (Person person in persons)
            {
                int previousPositionX = person.PositionX;
                int previousPositionY = person.PositionY;   
                if (person.PositionX + person.MoveX < 0)
                {
                    person.PositionX = city.GetLength(1) - 1;
                }
                if (person.PositionY + person.MoveY < 0)
                {
                    person.PositionY = city.GetLength(0) - 1;
                }
                if (person.PositionX + person.MoveX > city.GetLength(1) - 1)
                {
                    person.PositionX = 0;
                }
                if (person.PositionY + person.MoveY > city.GetLength(0) - 1)
                {
                    person.PositionY = 0;
                }
                else
                {
                    person.PositionY = person.PositionY + person.MoveY;
                    person.PositionX = person.PositionX + person.MoveX;
                }
                city[previousPositionY, previousPositionX] = null;
            }
            return persons;
        }
        public static List<Person> Generate(List<Person> persons)
        {
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                persons.Add(new Thief(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2), "", false, 0, false));
                persons.Add(new Police(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2), "", false));
                persons.Add(new Citizen(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2), "", false));
            }

            return persons;
        }
        public static void Compare(List<Person> persons, List<Person> prisoners)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                for (int j = 0; j < persons.Count; j++)
                {
                    if (i != j)
                    {
                        if (persons[i].PositionX == persons[j].PositionX && persons[i].PositionY == persons[j].PositionY)
                        {
                            if (persons[i] is Police)
                            {
                                ((Police)persons[i]).Interact(persons[j], persons, prisoners, i, j);
                            }
                            else
                            {
                                persons[i].Interact(persons[j], i, j);
                            }
                        }
                    }
                }
            }
        }

        public static void Draw(string[,] drawArray)
        {

            string frame = "#";

            for (int top = 0; top < drawArray.GetLength(1) + 2; top++)
            {
                Console.Write(frame);
            }
            Console.WriteLine();

            for (int row = 0; row < drawArray.GetLength(0); row++)
            {
                Console.Write(frame);
                for (int col = 0; col < drawArray.GetLength(1); col++)
                {
                    Console.Write(drawArray[row, col] == null ? " " : drawArray[row, col]);
                }
                Console.Write(frame);
                Console.WriteLine();
            }

            for (int bottom = 0; bottom < drawArray.GetLength(1) + 2; bottom++)
            {
                Console.Write(frame);
            }
            Console.WriteLine();
        }

        public static void Draw(string[,] drawArray, int offsetLeft)
        {
            string frame = "#";

            Console.SetCursorPosition(offsetLeft, 0);

            for (int top = 0; top < drawArray.GetLength(1) + 2; top++)
            {

                Console.Write(frame);
            }
            Console.WriteLine();

            for (int row = 0; row < drawArray.GetLength(0); row++)
            {
                Console.SetCursorPosition(offsetLeft, row + 1);
                Console.Write(frame);
                for (int col = 0; col < drawArray.GetLength(1); col++)
                {
                    Console.Write(drawArray[row, col] == null ? " " : drawArray[row, col]);
                }
                Console.Write(frame);
                Console.WriteLine();
            }
            var cursorRow = Console.GetCursorPosition();
            Console.SetCursorPosition(offsetLeft, cursorRow.Top);
            for (int bottom = 0; bottom < drawArray.GetLength(1) + 2; bottom++)
            {

                Console.Write(frame);
            }
            Console.WriteLine();

        }
        public static void CheckActivity(List<Person> persons, List<string> activity)
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

        public static void PrintPrisonStatus(List<Person> prisoners, string[,] prison, string[,] city)
        {
            Console.SetCursorPosition( city.GetLength(1) + 3, prison.GetLength(0) + 3);
            Console.WriteLine("There are currently " + prisoners.Count + " thief/thieves in prison");
            Console.SetCursorPosition(0, 0);
        }
        public static void PrintActivity(List<string> activity, string[,] city)
        {
            Console.SetCursorPosition(0, city.GetLength(0) + 3);
            for (int i = activity.Count - 1; i>activity.Count - 11 ; i--)
            {
                if (i > 0)
                {
                    Console.WriteLine(i + " " + activity[i] +"           ");
                    Console.WriteLine();
                }
            }
           
            Console.SetCursorPosition(0, 0);
        }

        public static void Updatepositions(string[,] city, string[,] prison, List<Person> persons, List<Person> prisoners)
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
                  
                        break;
                    }
                }
            }
        }
    }
}
