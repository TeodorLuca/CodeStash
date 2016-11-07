using System.Collections.ObjectModel;

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
