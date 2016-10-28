using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStash3.BLL;
using CodeStash3;
using System.Web.Script.Serialization;
using System.IO;


namespace CodeStash3.DAL
{
    public class SnippetRepository : ISnippetRepository
    {
        
        public SnippetRepository()
        {
            //LoadData("jsondb.tmp");
        }

        public List<Snippet> GetAllSnippets()
        {
            return Deserialize();
        }

        private List<Snippet> Deserialize()
        {

            string dbFileName = CodeStash3.DAL.Properties.Settings.Default.jsonDB;
            string snippetStr = File.ReadAllText(dbFileName);
            List<Snippet> snippets = new JavaScriptSerializer().Deserialize<List<Snippet>>(snippetStr);
            return snippets;
            //return new List<Snippet> {new Snippet() { Title = "item1", Language = "C", Code = "some C code\nnewline" },
            //                          new Snippet() { Title = "item2", Language = "C++", Code = "some C++ code" },
            //                          new Snippet() { Title = "item3", Language = "C#", Code = "some C# code" }  };
        }

        public void UpdateAllSnippets(List<Snippet> snippets)
        {
            Serialize(snippets);
        }

        private void Serialize(List<Snippet> snippets)
        {
            string dbFileName = CodeStash3.DAL.Properties.Settings.Default.jsonDB;
            var json = new JavaScriptSerializer().Serialize(snippets);
            File.WriteAllText(dbFileName, json);
        }
    }
}
