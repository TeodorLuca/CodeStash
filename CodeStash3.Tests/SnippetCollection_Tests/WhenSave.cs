using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeStash3.BLL;
using CodeStash3.DAL;

namespace CodeStash3.BLL_Tests.SnippetCollection_Tests
{
    [TestClass]
    public class WhenSave
    {
        static string originalValueJsonDb;
        static string originalValueRepoType;

        #region Additional test attributes
        [TestInitialize()]
        public void MyTestInitialize()
        {
            originalValueJsonDb = CodeStash3.DAL.Properties.Settings.Default.jsonDB;
            originalValueRepoType = CodeStash3.DAL.Properties.Settings.Default.repoType;
            CodeStash3.DAL.Properties.Settings.Default.jsonDB = "testJsonDb.txt";
            CodeStash3.DAL.Properties.Settings.Default.repoType = "json";
        }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            CodeStash3.DAL.Properties.Settings.Default.jsonDB = originalValueJsonDb;
            CodeStash3.DAL.Properties.Settings.Default.repoType = originalValueRepoType;
        }

        #endregion

        // for review: this method needs to be deleted. It doesn't make sense anymore because it was supposed to check that repo.Update() method is called when 
        // snippetCollection.Save() is called, but there is no Save() method anymore; instead the ViewModel calls directly repo.Update()
        //[TestMethod]
        //public void ThenTheRepositoryUpdateMethodIsCalled()
        //{
        //    MockSnippetRepository _repo = new MockSnippetRepository(new List<Snippet>());
        //    SnippetCollection snippetCollection = new SnippetCollection(_repo);
        //    snippetCollection.Save();
        //    Assert.IsTrue(_repo.GetAllSnippetsWasCalled); // make it fail
        //    Assert.IsTrue(_repo.UpdateWasCalled);
        //}


        //integration test
        [TestMethod]
        public void ThenTheContentIsPersistentInFile()
        {
            SnippetRepository _repo = new SnippetRepository();
            SnippetCollection snippetCollection = new SnippetCollection();

            Snippet testSnippet = new Snippet() { Code = "test code", Title = "Test Snippet", Language = "Test Language" };
            snippetCollection.Add(testSnippet);
            _repo.UpdateAllSnippets(snippetCollection);

            SnippetCollection actualSnippetCollection = new SnippetCollection();
            actualSnippetCollection.AddRange(_repo.GetAllSnippets());
            SnippetCollection expectedSnippetCollection = new SnippetCollection() { testSnippet };

            Assert.AreEqual(actualSnippetCollection.ToString(), expectedSnippetCollection.ToString());
            Assert.IsTrue(actualSnippetCollection.Count == 1);
        }
    }
}
