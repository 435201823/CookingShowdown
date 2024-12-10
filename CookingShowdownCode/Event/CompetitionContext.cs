using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event
{
    public class CompetitionContext
    {
        private static CompetitionContext? _instance;
        public static CompetitionContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompetitionContext();
                }
                return _instance;
            }
        }

        private CompetitionContext()
        {
        }

        public Item? cookItem;

        public void setCookItem(Item item)
        {
            this.cookItem = item;
        }
    }
}
