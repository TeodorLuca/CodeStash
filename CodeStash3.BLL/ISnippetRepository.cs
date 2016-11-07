using System.Collections.Generic;

namespace CodeStash3.BLL
{
    public interface ISnippetRepository
    {
        void UpdateAllSnippets(List<Snippet> snippets);

        List<Snippet> GetAllSnippets();
    }
}
