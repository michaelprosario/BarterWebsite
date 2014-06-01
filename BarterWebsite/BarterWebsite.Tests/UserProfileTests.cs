using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarterWebsite.Models;

namespace BarterWebsite.Tests
{
    [TestClass]
    public class UserProfileTests
    {
        [TestMethod]
        public void UserProfileRepo__Add__ItWorks()
        {
            UserProfileRepo t = new UserProfileRepo();
            UserProfile r = getTestRecord();

            int recordID = 0;
            try
            {
                recordID = t.AddRecord(r);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Assert.IsTrue(t.RecordExists(recordID), "record should exist.");
        }

        private static UserProfile getTestRecord()
        {
            UserProfile r = new UserProfile();
            r.UserName = "testguy";
            r.LinkedInUrl = "";
            r.LinkToAmazon = "";
            r.LinkToEbay = "";
            r.TwitterAccount = "";
            return r;
        }

        [TestMethod]
        public void UserProfileRepo__Delete__ItWorks()
        {
            UserProfileRepo t = new UserProfileRepo();
            UserProfile r = getTestRecord();

            int recordID = 0;
            recordID = t.AddRecord(r);
            Assert.IsTrue(t.RecordExists(recordID), "record should exist.");


            t.DeleteRecord(recordID);
            Assert.IsTrue(!t.RecordExists(recordID), "record not exist.");
        }

        [TestMethod]
        public void UserProfileRepo__Update__ItWorks()
        {
            UserProfileRepo t = new UserProfileRepo();
            UserProfile r = getTestRecord();

            int recordID = 0;
            recordID = t.AddRecord(r);
            Assert.IsTrue(t.RecordExists(recordID), "record should exist.");

            //arrange ......
            UserProfile r2 = t.GetRecord(recordID);
            r2.TwitterAccount = "http://www.twitter.com/hackforchange";
            t.UpdateRecord(r2);

            //act ...........
            UserProfile r3 = t.GetRecord(recordID);
            Assert.IsTrue(r2.TwitterAccount == r3.TwitterAccount);

        }



    }
}
