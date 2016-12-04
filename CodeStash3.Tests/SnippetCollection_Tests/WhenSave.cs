using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeStash3.BLL;
using CodeStash3.DAL;
using CodeStash3;

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
            originalValueRepoType = CodeStash3.DAL.Properties.Settings.Default.vc;
            CodeStash3.DAL.Properties.Settings.Default.jsonDB = "testJsonDb.txt";
            CodeStash3.DAL.Properties.Settings.Default.vc = "json";
        }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            CodeStash3.DAL.Properties.Settings.Default.jsonDB = originalValueJsonDb;
            CodeStash3.DAL.Properties.Settings.Default.vc = originalValueRepoType;
        }

        #endregion

        //integration test
        [TestMethod]
        public void ThenTheContentIsPersistentInFile()
        {
            ISnippetRepository _repo = new SnippetRepositoryFactory().GetRepository(CodeStash3.DAL.Properties.Settings.Default.vc);
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
