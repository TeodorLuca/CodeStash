using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeStash3.BLL;
using System.Collections.Generic;

namespace CodeStash3.BLL_Tests.SnippetCollection_Tests
{
    [TestClass]
    public class WhenGenerateLanguageList
    {
        [TestMethod]
        public void ThenTheListOfLanguageTypesIsGenerated()
        {
            MockSnippetRepository _repo = new MockSnippetRepository(Mother.GetSnippets());
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            List<Snippet> fromRepoSnippets = snippetCollection.GetAllSnippets();
            LanguageCollection languageCollection = new LanguageCollection(fromRepoSnippets);
            List<string> listOfLanguageTypes = languageCollection.GenerateLanguageList();
            listOfLanguageTypes.Sort();
            string current = listOfLanguageTypes.ToString();
            List<string> listOfLanguageTypesExpected = Mother.GetLanguageList();
            listOfLanguageTypesExpected.Sort();
            string expected = listOfLanguageTypesExpected.ToString();
            //Assert.IsTrue(String.Equals(expected,"bubu")); // make test fail
            Assert.IsTrue(String.Equals(expected, current));
        }
    }
}
