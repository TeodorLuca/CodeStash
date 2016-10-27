using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStash3.BLL
{
    public interface ISnippetRepository
    {
        void AddSnippet(Snippet snippet);
        void DeleteSnippet(Snippet snippet);
        void UpdateSnippet(Snippet snippet);
        List<Snippet> GetAllSnippets();
    }
}
