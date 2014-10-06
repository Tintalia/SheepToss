using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepToss
{
    public abstract class Character : ILivable
    {
        public int HP { get; set; }
    }
}
