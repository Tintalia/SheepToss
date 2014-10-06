using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepToss
{
    public abstract class Dragon : Character, IMovable, ILivable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Attack { get; set; } //Projectile attack value + bonuses (if there are any)
        public int Speed { get; set; }
        public int Armor { get; set; }
        public int Firepower { get; set; }
        public int ShotLimit { get; set; }
        public int Venom { get; set; }
        public int JawStrength { get; set; }
        public int Stealth { get; set; }
    }
}
