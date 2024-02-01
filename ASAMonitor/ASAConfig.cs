using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAMonitor
{
    public class ASAConfig
    {
        public bool Paused { get; set; } = false;

        public bool NoBattleEye { get; set; } = true;

        public int WinLiveMaxPlayers { get; set; } = 20;

        public bool ForceAllowCaveFlyers { get; set; } = true;

        public List<int> Mods { get; set; } = new List<int>();
    }
}
