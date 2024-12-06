using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event
{
    public class NpcPosition
    {
        public string npcId;
        public int x;
        public int y;

        public NpcPosition(string npcId, int x, int y)
        {
            this.npcId = npcId;
            this.x = x;
            this.y = y;
        }
    }
}
