using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Methods
    {
        public static List<Person> Generate(List<Person> persons)
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                persons.Add(new Thief(random.Next(0, 25), random.Next(0, 100)));
                persons.Add(new Police(random.Next(0, 25), random.Next(0, 100)));
                persons.Add(new Citizen(random.Next(0, 25), random.Next(0, 100)));
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
