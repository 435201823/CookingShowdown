using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode
{
    public class InnerTranslator
    {
        private static ITranslationHelper? translationHelper;

        public static void init(ITranslationHelper translationHelper)
        {
            InnerTranslator.translationHelper = translationHelper;
        }

        public static string getTranslate(string key)
        {
            if (translationHelper == null)
            {
                throw new Exception("I18N error,TranslationHelper is null");
            }
            
            return translationHelper.Get(key);
        }

        public static string getTranslate(string key, object? tokens)
        {
            if (translationHelper == null)
            {
                throw new Exception("I18N error,TranslationHelper is null");
            }

            return translationHelper.Get(key, tokens);
        }
    }
}
