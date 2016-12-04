using System;
using System.Collections.Generic;
using CodeStash3.BLL;
using CodeStash3.DAL.Properties;

namespace CodeStash3.DAL
{
    public class SnippetRepositoryFactory
    {
        public static ISnippetRepository GetRepository(string repositoryType)
        {
            ISnippetRepository repository;
            switch (repositoryType.ToLower())
            {
                case "json": { repository = new JsonSnippetRepository(); break; }
                case "sql": { repository = new SqlSnippetRepository(); break; }
                default: throw new Exception("Repository type not valid");
            }
            return repository;
        }
    }
}
