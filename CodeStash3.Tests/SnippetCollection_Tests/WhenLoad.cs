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
            MockSnippetRepository _repo = new MockSnippetRepository(new List<Snippet>());
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            //snippetCollectionGetAllSnippets();
            //Assert.IsTrue(_repo.UpdateWasCalled); // make it fail
            Assert.IsTrue(_repo.GetAllSnippetsWasCalled);
        }


        //integration
        [TestMethod]
        public void ThenTheContentOfListIsTheSameWithFile()
        {

            MockSnippetRepository _repo = new MockSnippetRepository(Mother.GetSnippets());
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            //List<Snippet> fromRepoSnippets = snippetCollection.GetAllSnippets();
            string curent = snippetCollection.ToString();
            string expected = Mother.GetSnippets().ToString();
            //Assert.IsTrue(String.Equals(curent, "bubu")); // make it fail
            Assert.IsTrue(String.Equals(curent, expected));
        }
    }
}
