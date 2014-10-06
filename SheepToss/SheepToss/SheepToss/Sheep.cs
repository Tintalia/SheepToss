using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepToss
{
    abstract class Sheep : IMovable
    {
        public int LifePoints { get; set; } // The number life points it adds to the dragon after being collected
    }
}
