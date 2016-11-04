using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStash3.BLL;
using CodeStash3.DAL.Properties;

namespace CodeStash3.DAL
{
    public class SnippetRepository : ISnippetRepository
    {
        private ISnippetRepository repository;
        public SnippetRepository()
        {
            string repositoryType = Settings.Default.repoType;
            switch (repositoryType)
            {
                case "json": { repository = new JsonSnippetRepository(); break; }
                case "sql" : { repository = new SqlSnippetRepository(); break; }
                default: throw new NotImplementedException();
            }

        }

        public List<Snippet> GetAllSnippets()
        {
            return repository.GetAllSnippets();
        }

        public void UpdateAllSnippets(List<Snippet> snippets)
        {
            repository.UpdateAllSnippets(snippets);
        }
    }
}
