using CookingShowdownCode.Enum;
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
        public int face;

        public NpcPosition(CharacterEnum character, int x, int y, DirectionEnum direction): this(character.GetName(), x, y, (int)direction)
        {
        }

        public NpcPosition(string npcId, int x, int y,int face)
        {
            this.npcId = npcId;
            this.x = x;
            this.y = y;
            this.face = face;
        }
    }
}
