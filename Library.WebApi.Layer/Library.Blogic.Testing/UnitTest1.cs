using System;
using Library.BLogic.Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Blogic.Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod1()
        {
            AuthorActions aa = new AuthorActions();
            
            var xyz = aa.GetAuthorByName("genelia");
            Assert.ThrowsException<NullReferenceException>(xyz);

        }
    }
}
