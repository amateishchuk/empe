using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Empeek.Domain.Abstract;
using Empeek.Domain.Concrete;
using Empeek.Domain.Entities;
using System.Collections.Generic;

namespace Empeek.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IOwnerRepository repo = new SQLiteOwnerRepository();
            List<User> result = (List<User>) repo.Users;
            Assert.AreEqual(5, result.Count);

        }
    }
}
