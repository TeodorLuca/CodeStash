using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeStash3.BLL
{
    public class LanguageCollection
    {
        private List<Snippet> snippets;
        public LanguageCollection(List<Snippet> snippets)
        {
            this.snippets = snippets;
        }

        public List<string> GenerateLanguageList()
        {
            List<string> languages = snippets.Select(x => x.Language).ToList();
            return languages.Distinct().ToList();
            
        }
    }
}