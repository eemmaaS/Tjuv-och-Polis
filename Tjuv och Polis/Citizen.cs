﻿namespace Tjuv_och_Polis
{
    internal class Citizen : Person
    {
        public Citizen(int positionX, int positionY, int moveX, int moveY) : base(positionX, positionY, moveX, moveY)
        {
            this.Inventory.Add(new Thing("Nycklar"));
            this.Inventory.Add(new Thing("Plånbok"));
            this.Inventory.Add(new Thing("Mobiltelefon"));
            this.Inventory.Add(new Thing("Klocka"));
        }
        public override char Marker => 'M';

        public override Person Interact(Person person, int indexi, int indexj)
        {
            if (person is Citizen)
            {

            }
            return person;
        }
    }
}
