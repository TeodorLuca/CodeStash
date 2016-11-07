using System.Collections.Generic;

namespace CodeStash3.Model
{
    public class LanguageCollection:List<string>
    {
        public LanguageCollection(List<string> languageCollection)
        {
            this.AddRange(languageCollection);
        }
    }
}
