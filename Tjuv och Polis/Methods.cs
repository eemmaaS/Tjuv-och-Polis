using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{ //test123
    internal class Methods
    {
        public static List<Person> Move(List<Person> persons, string[,]city)
        {
            foreach (Person person in persons)
            {
                if (person.PositionX + person.MoveX < 0)
                { 
                    person.PositionX = city.GetLength(1) - 1;
                }
                if (person.PositionY + person.MoveY < 0)
                { 
                    person.PositionY = city.GetLength(0)-1;
                }
                if (person.PositionX + person.MoveX > city.GetLength(1)-1)
                {
                    person.PositionX = 0;
                }
                if (person.PositionY + person.MoveY > city.GetLength(0)-1)
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
            for (int i = 0; i < 5; i++)
            {
                persons.Add(new Thief(random.Next(0, 100), random.Next(0, 25),random.Next(-1,2), random.Next(-1,2)));
                persons.Add(new Police(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
                persons.Add(new Citizen(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
            }

            return persons;
        }

        public static void Draw(string[,] cityDraw)
        {
            
            string frame = "#";

            for (int top = 0; top < cityDraw.GetLength(1) + 2; top++)
            {
                Console.Write(frame);
            }
            Console.WriteLine();

            for (int row = 0; row < cityDraw.GetLength(0); row++)
            {
                Console.Write(frame);
                for (int col = 0; col < cityDraw.GetLength(1); col++)
                {
                    Console.Write(cityDraw[row, col] == null ? " " : cityDraw[row, col]);
                }
                Console.Write(frame);
                Console.WriteLine();
            }

            for (int bottom = 0; bottom < cityDraw.GetLength(1) + 2; bottom++)
            {
                Console.Write(frame);
            }
            Console.WriteLine();
        }
    }
}
