using CodeStash3.BLL;
using System.Collections.Generic;

namespace CodeStash3.BLL_Tests.SnippetCollection_Tests
{
    class MockSnippetRepository : ISnippetRepository
    {
        public bool UpdateWasCalled = false;
        public List<Snippet> Snippets;// = Mother.GetSnippets();
        public bool GetAllSnippetsWasCalled = false;

        public MockSnippetRepository(List<Snippet> snippets)
        {
            Snippets = snippets;
        }
        public List<Snippet> GetAllSnippets()
        {
            GetAllSnippetsWasCalled = true;
            return Snippets;
        }

        public void UpdateAllSnippets(List<Snippet> snippets)
        {
            UpdateWasCalled = true;
            Snippets = snippets;
        }
    }
}
