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

        private Item? cookItem;

        internal void CompetitionStart()
        {
            this.cookItem = null;
        }

        public void setCookItem(Item item)
        {
            this.cookItem = item;
        }

        public Item? getCookItem()
        {
            return this.cookItem;
        }

        internal async Task WaitForCook()
        {
            while(this.cookItem == null)
            {
                await Task.Delay(100);
            }
        }
    }
}
