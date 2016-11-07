using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeStash3.BLL;
using System.Collections.Generic;

namespace CodeStash3.BLL_Tests.SnippetCollection_Tests
{
    [TestClass]
    public class WhenLoad
    {
        [TestMethod]
        public void ThenTheRepositoryGetAllSnippetsMethodIsCalled()
        {
            MockSnippetRepository _repo = new MockSnippetRepository(new List<Snippet>());
            SnippetCollection snippetCollection = new SnippetCollection(_repo);

            Assert.IsTrue(_repo.GetAllSnippetsWasCalled);
        }

        [TestMethod]
        public void ThenTheContentOfListIsTheSameWithFile()
        {
            MockSnippetRepository _repo = new MockSnippetRepository(Mother.GetSnippets());
            SnippetCollection actualSnippetCollection = new SnippetCollection(_repo);

            SnippetCollection expectedSnippetCollection = new SnippetCollection();
            expectedSnippetCollection.AddRange(Mother.GetSnippets());

            Assert.AreEqual(actualSnippetCollection.ToString(), expectedSnippetCollection.ToString());
        }
    }
}
