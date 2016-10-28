using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeStash3.BLL
{
    public class SnippetCollection:ISnippetRepository
    {
        ISnippetRepository _repo;
        public SnippetCollection(ISnippetRepository repo)
        {
            _repo = repo;
        }
        
        
        public List<Snippet> GetAllSnippets()
        {
            return _repo.GetAllSnippets();
        }

        public void UpdateAllSnippets(List<Snippet> snippets)
        {
            _repo.UpdateAllSnippets(snippets);
        }
        
    }
}
