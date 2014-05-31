using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarterWebsite.Models;

namespace BarterWebsite.Tests
{
    [TestClass]
    public class CategoriesRepoTests
    {

        [TestMethod]
        public void CategoriesRepo__AddRecord__DoesItWork()
        {
            //arrange
            CategoriesRepo categories = new CategoriesRepo();
            Category aCategory = new Category();
            aCategory.Category1 = "TestCategory";

            //act 
            int recordID = categories.AddRecord(aCategory);


            //assert 
            Assert.IsTrue(categories.RecordExists(recordID), "record should exist");
        }

        [TestMethod]
        public void CategoriesRepo__RecordExists__TestFalseCase()
        {
            //arrange
            CategoriesRepo categories = new CategoriesRepo();


            //act 
            bool result = categories.RecordExists(int.MaxValue);


            //assert 
            Assert.IsTrue(result == false, "result should be false.");
        }



    }
}
