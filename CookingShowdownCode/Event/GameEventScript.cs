using CookingShowdownCode.Event.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event
{
    public class GameEventScript
    {
        private String musicId;
        private int startCameraX;
        private int startCameraY;
        private List<NpcPosition> npcPositions;

        private List<GameEventCommand> commands = new();

        public GameEventScript(string musicId, int startCameraX, int startCameraY, List<NpcPosition> npcPositions)
        {
            this.musicId = musicId;
            this.startCameraX = startCameraX;
            this.startCameraY = startCameraY;
            this.npcPositions = npcPositions;
        }

        public void AddCommand(GameEventCommand command)
        {
            commands.Add(command);
        }

        public string GenerateEventScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(musicId);
            sb.Append("/");

            sb.Append(startCameraX);
            sb.Append(' ');
            sb.Append(startCameraY);
            sb.Append("/");

            int cnt = 0;
            foreach (NpcPosition npc in npcPositions)
            {
                if (cnt++ != 0)
                {
                    sb.Append(' ');
                }
                sb.Append(npc.npcId);
                sb.Append(' ');
                sb.Append(npc.x);
                sb.Append(' ');
                sb.Append(npc.y);
                sb.Append(' ');
                sb.Append(npc.face);
            }

            foreach (GameEventCommand command in commands)
            {
                sb.Append('/');
                sb.Append(command.getCommandString());
            }
            return sb.ToString();
        }
    }
}
