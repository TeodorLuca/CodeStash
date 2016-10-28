using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeStash3.BLL;


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
            MockSnippetRepository _repo = new MockSnippetRepository(null);
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            snippetCollection.UpdateAllSnippets(null);
            //Assert.IsTrue(_repo.GetAllSnippetsWasCalled); // make it fail
            Assert.IsTrue(_repo.UpdateWasCalled);
        }

        [TestMethod]
        public void ThenTheContentIsPersistentInFile()
        {
            
            MockSnippetRepository _repo = new MockSnippetRepository(null);
            SnippetCollection snippetCollection = new SnippetCollection(_repo);
            List<Snippet> newSnippets = Mother.GetSnippets();
            snippetCollection.UpdateAllSnippets(newSnippets);
            //bool result = newSnippets.Equals("bubu"); // make it fail
            bool result = newSnippets.Equals(_repo.Snippets);
            Assert.IsTrue(result);

        }
    }



}
