using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeStash3.BLL;
using CodeStash3.DAL;

namespace CodeStash3.BLL_Tests.SnippetCollection_Tests
{
    /// <summary>
    /// Summary description for WhenSave
    /// </summary>
    [TestClass]
    public class WhenSave
    {
        public WhenSave()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        
        //Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize(List<Snippet> snippets)
        //{
        //    MockSnippetRepository _repo = new MockSnippetRepository(snippets);
        //    SnippetCollection TestSnippetCollection = new SnippetCollection(_repo);
        //}
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ThenTheRepositoryUpdateMethodIsCalled()
        {
            MockSnippetRepository _repo = new MockSnippetRepository(new List<Snippet>());
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            snippetCollection.Save();
            //Assert.IsTrue(_repo.GetAllSnippetsWasCalled); // make it fail
            Assert.IsTrue(_repo.UpdateWasCalled);
        }


        //integration test
        [TestMethod]
        public void ThenTheContentIsPersistentInFile()
        {
            SnippetRepository _repo = new SnippetRepository();
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            Snippet testSnippet = new Snippet() { Code = "test code", Title = "Test Snippet", Language = "Test Language" };
            snippetCollection.Add(testSnippet);
            snippetCollection.Save();
            List<Snippet> currentRepo = _repo.GetAllSnippets();
            Assert.IsTrue(currentRepo.Contains(new Snippet() {Title = "fake", Code = "fake", Language = "fake" })); // make test fail
            Assert.IsTrue(currentRepo.Contains(testSnippet));

        }
    }



}
