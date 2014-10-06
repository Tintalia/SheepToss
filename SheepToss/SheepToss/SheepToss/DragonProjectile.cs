using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepToss
{
    class DragonProjectile : Projectile
    {
        public DragonProjectileType type { get; set; }
        public int Attack { get; set; }
    }
}
