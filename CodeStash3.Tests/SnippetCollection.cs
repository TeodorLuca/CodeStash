using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeStash3.BLL
{
    public class SnippetCollection : List<Snippet>
    {

        ISnippetRepository _repo;
        public SnippetCollection(ISnippetRepository repo)
        {
            _repo = repo;
            this.AddRange(_repo.GetAllSnippets());
        }

        public SnippetCollection()
        {

        }

        public override string ToString()
        {
            return string.Join(System.Environment.NewLine, this.Select(s => s.ToString()));
        }
    }
}
