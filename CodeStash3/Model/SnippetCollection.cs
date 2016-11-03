using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStash3.Model
{
    class SnippetCollection: ObservableCollection<Snippet>
    {
        public SnippetCollection(BLL.SnippetCollection snippetCollection)
        {
            foreach (BLL.Snippet snippet in snippetCollection)
            {
                this.Add(new Snippet(snippet));
            }
        }
    }
}
