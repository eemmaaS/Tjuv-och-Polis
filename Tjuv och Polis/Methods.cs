using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Methods
    {
        public static List<Person> Move(List<Person> persons, string[,]city)
        {
            foreach (Person person in persons)
            {
                person.PositionY = person.PositionY + person.MoveY;
                person.PositionX = person.PositionX + person.MoveX;

                if (person.PositionX < 0)
                {
                    person.PositionX = city.GetLength(1) - 1;
                }
                if (person.PositionY < 0)
                { 
                    person.PositionY = city.GetLength(0)-1;
                }
                if (person.PositionX > city.GetLength(1)-1)
                {
                    person.PositionX = 0;
                }
                if (person.PositionY > city.GetLength(0))
                {
                    person.PositionY = 0;
                }
               
                
                    person.PositionY = person.PositionY + person.MoveY;
                    person.PositionX = person.PositionX + person.MoveX;
                
            }
            return persons;
        }
        public static List<Person> Generate(List<Person> persons)
        {
            Random random = new Random();
            //for (int i = 0; i < 5; i++)
            //{
            //    persons.Add(new Thief(random.Next(0, 100), random.Next(0, 25),random.Next(-1,2), random.Next(-1,2)));
            //    persons.Add(new Police(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
            //    persons.Add(new Citizen(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
            //}
            persons.Add(new Thief(40, 15, 0, -1));
            //persons.Add(new Police(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
            //persons.Add(new Citizen(random.Next(0, 100), random.Next(0, 25), random.Next(-1, 2), random.Next(-1, 2)));
            return persons;
        }

        public static void Draw(string[,] cityDraw)
        {
            
            string frame = "#";

            for (int top = 0; top < cityDraw.GetLength(0) + 2; top++)
            {
                Console.Write(frame);
            }
            Console.WriteLine();

            for (int row = 0; row < cityDraw.GetLength(1); row++)
            {
                Console.Write(frame);
                for (int col = 0; col < cityDraw.GetLength(0); col++)
                {
                    Console.Write(cityDraw[row, col] == null ? " " : cityDraw[row, col]);
                }
                Console.Write(frame);
                Console.WriteLine();
            }

            for (int bottom = 0; bottom < cityDraw.GetLength(0) + 2; bottom++)
            {
                Console.Write(frame);
            }
            Console.WriteLine();
        }
    }
}
