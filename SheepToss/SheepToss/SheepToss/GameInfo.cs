using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepToss
{
    class GameInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan RemainingTime { get; set; }
        public int Points { get; set; }
    }
}
