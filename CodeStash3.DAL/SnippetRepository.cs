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

        private void LoadData(string dbFileName)
        {
            //CodeStash3.DAL.Properties.Settings.Default.jsonDB

            List<Snippet> snippets = new List<Snippet>();
            Stream fd = File.Open(dbFileName, FileMode.OpenOrCreate);
            var json = new JavaScriptSerializer().Deserialize<List<Snippet>>(fd.ToString());
            fd.Close();

        }

        

        public void AddSnippet(Snippet snippet)
        {
            throw new NotImplementedException();
        }

        public void DeleteSnippet(Snippet snippet)
        {
            throw new NotImplementedException();
        }

        public List<Snippet> GetAllSnippets()
        {
            return new List<Snippet>();
        }

        public void UpdateSnippet(Snippet snippet)
        {
            throw new NotImplementedException();
        }
    }
}
