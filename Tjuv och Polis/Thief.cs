using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv_och_Polis
{
    internal class Thief : Person
    {
        public Thief(int positionX, int positionY, int moveX, int moveY) : base(positionX, positionY, moveX, moveY)
        {

        }
        public override char Marker => 'T';

        public override void Interact()
        {

        }
    }
}
