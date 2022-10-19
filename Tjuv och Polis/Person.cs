﻿namespace Tjuv_och_Polis
{
    internal class Person
    {
        public Person(int positionX, int positionY, int moveX, int moveY)
        {
            PositionX = positionX;
            PositionY = positionY;
            MoveX = moveX;
            MoveY = moveY;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int MoveX { get; set; }
        public int MoveY { get; set; }


        public List<Thing> Inventory { get; set; } = new List<Thing>();

        public virtual char Marker { get; set; }

        public virtual Person Interact(Person person, int indexi, int indexj)
        {
            return person;
        }
    }
}
