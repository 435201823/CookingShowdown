using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class AddConversationTopic : GameEventCommand
    {
        public string topicID;

        public AddConversationTopic(string topicID)
        {
            this.topicID = topicID;
        }

        public string getCommandString()
        {
            return "addConversationTopic " + topicID;
        }
    }
}
