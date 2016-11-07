using System.Collections.Generic;
using System.Linq;


namespace CodeStash3.BLL
{
    public class SnippetCollection: List<Snippet>
    {
               
        ISnippetRepository _repo;
        public SnippetCollection(ISnippetRepository repo)
        {
            try
            {
                _repo = repo;
                this.AddRange(_repo.GetAllSnippets());
            }
            catch
            {
                throw;
            }
            
        }

        public SnippetCollection()
        {

        }
        public void GenerateRich()
        {
            //iterette and call snippet.GenerateRich();
        }

        public override string ToString()
        {
            return string.Join(System.Environment.NewLine, this.Select(s => s.ToString()));
        }
    }
}
