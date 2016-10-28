using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeStash3.BLL;
using System.Collections.Generic;
using System.Linq;

namespace CodeStash3.BLL_Tests.SnippetCollection_Tests
{
    [TestClass]
    public class WhenLoad
    {
        [TestMethod]
        public void ThenTheRepositoryGetAllSnippetsMethodIsCalled()
        {
            MockSnippetRepository _repo = new MockSnippetRepository(null);
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            snippetCollection.GetAllSnippets();
            //Assert.IsTrue(_repo.UpdateWasCalled); // make it fail
            Assert.IsTrue(_repo.GetAllSnippetsWasCalled);
        }

        [TestMethod]
        public void ThenTheContentOfListIsTheSameWithFile()
        {

            MockSnippetRepository _repo = new MockSnippetRepository(Mother.GetSnippets());
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            List<Snippet> fromRepoSnippets = snippetCollection.GetAllSnippets();
            string curent = fromRepoSnippets.ToString();
            string expected = Mother.GetSnippets().ToString();
            //Assert.IsTrue(String.Equals(curent, "bubu")); // make it fail
            Assert.IsTrue(String.Equals(curent, expected));
        }
    }
}
