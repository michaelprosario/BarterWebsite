using BarterWebsite.Filters;
using BarterWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BarterWebsite.Controllers
{
    [InitializeSimpleMembership]
    public class MyProfileController : Controller
    {

        [Authorize]
        public ActionResult Edit()
        {

            //Load the user in question ...
            int recordID = getUserID();

            //Put user data into the view ...
            UserProfileRepo users = new UserProfileRepo();
            UserProfile aUser = users.GetRecord(recordID);

            return View(aUser);
        }

        private int getUserID()
        {
            string userName = User.Identity.Name;
            int recordID = WebSecurity.GetUserId(userName);
            return recordID;
        }

        //
        // POST: /MyProfile/Edit/5

        [HttpPost]
        public ActionResult Edit( FormCollection collection)
        {
            var t = new UserProfileRepo();
            int id = getUserID();
            UserProfile r = t.GetRecord(id);
            r.BlogURL = collection["BlogURL"];
            r.CompanyUrl = collection["CompanyUrl"];
            r.LinkedInUrl = collection["LinkedInUrl"];
            r.LinkToAmazon = collection["LinkToAmazon"];
            r.LinkToEbay = collection["LinkToEbay"];
            r.TwitterAccount = collection["TwitterACcount"];
            t.UpdateRecord(r);

            return RedirectToAction("Index", "Home");
        }


    }
}
