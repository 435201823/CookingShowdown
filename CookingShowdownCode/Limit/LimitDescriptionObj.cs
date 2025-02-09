using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Limit
{
    public class LimitDescriptionObj
    {
        public string key;
        public object? tokens;

        public LimitDescriptionObj(string key, object? tokens)
        {
            this.key = key;
            this.tokens = tokens;
        }
    }
}
