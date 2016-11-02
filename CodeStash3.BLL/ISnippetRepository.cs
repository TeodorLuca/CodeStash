using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStash3.BLL
{
    public interface ISnippetRepository
    {
        void UpdateAllSnippets(List<Snippet> snippets);

        List<Snippet> GetAllSnippets();
    }
}
