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
        public void AddSnippet(Snippet snippet)
        {
            _repo.AddSnippet(snippet);
        }

        public void DeleteSnippet(Snippet snippet)
        {
            _repo.DeleteSnippet(snippet);
        }

        public List<Snippet> GetAllSnippets()
        {
            return _repo.GetAllSnippets();
        }

        public void UpdateSnippet(Snippet snippet)
        {
            _repo.UpdateSnippet(snippet);
        }
        
    }
}
