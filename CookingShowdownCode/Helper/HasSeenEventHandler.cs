using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Helper
{
    public class HasSeenEventHandler
    {
        private int? year;
        private Season? season;
        private int? day;

        public bool trySet(int year,Season season,int day)
        {
            if (year == this.year && season == this.season && day == this.day)
            {
                return false;
            } else
            {
                this.year = year;
                this.season = season;
                this.day = day;
                return true;
            }

        }
    }
}
