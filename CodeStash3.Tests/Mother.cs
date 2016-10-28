using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStash3.BLL;

namespace CodeStash3.BLL_Tests
{
    class Mother
    {
        public static List<Snippet> GetSnippets()
        {
            List<Snippet> Snippets = new List<Snippet>()
            {
                new Snippet() { Title = "item1", Language = "C", Code = "some C code\nnewline" },
                new Snippet() { Title = "item2", Language = "C++", Code = "some C++ code" },
                new Snippet() { Title = "item3", Language = "C#", Code = "some C# code" }
            };

            return Snippets;
        }
    }
}
