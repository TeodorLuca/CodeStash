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
            LanguageCollection languageCollection = new LanguageCollection(snippetCollection);

            List<string> actualListOfLanguageTypes = languageCollection.GenerateLanguageList();
            List<string> expectedListOfLanguageTypesExpected = Mother.GetLanguageList();

            actualListOfLanguageTypes.Sort();
            expectedListOfLanguageTypesExpected.Sort();

            Assert.AreEqual(expectedListOfLanguageTypesExpected.ToString(), actualListOfLanguageTypes.ToString());
        }
    }
}
