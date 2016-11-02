using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStash3.Model
{
    public class LanguageCollection:List<string>
    {
        public LanguageCollection(BLL.LanguageCollection languageCollection)
        {
            this.AddRange(languageCollection
        }
    }
}
