namespace Tjuv_och_Polis
{
    internal class Methods
    {
        public static List<Person> Move(List<Person> persons, string[,] city)
        {
            foreach (Person person in persons)
            {
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
            }
            return persons;
        }
        public static List<Person> Generate(List<Person> persons)
        {
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                persons.Add(new Thief(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
                persons.Add(new Police(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
                persons.Add(new Citizen(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
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
                                ((Police)persons[i]).Interact(persons[j],persons, prisoners,i,j);
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
    }
}
