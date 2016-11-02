using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeStash3.BLL
{
     public class SnippetCollection: List<Snippet> //:ISnippetRepository
    {
               
        ISnippetRepository _repo;
        public SnippetCollection(ISnippetRepository repo)
        {
            _repo = repo;
            this.AddRange(_repo.GetAllSnippets());
        }

        //other uses for 
        public void Validate()
        {
            //
        }

        public void Security()
        {
            //
        }

        public void BusinesRules()
        {
            //
        }

        public void GenerateRich()
        {
            //iterette and call snippet.GenerateRich();
        }


        public void Save()
        {
            _repo.UpdateAllSnippets(this);
        }
        
        
        //public List<Snippet> GetAllSnippets()
        //{
        //    return _repo.GetAllSnippets();
        //}

        //public void UpdateAllSnippets(List<Snippet> snippets)
        //{
        //    _repo.UpdateAllSnippets(snippets);
        //}
        
    }
}
