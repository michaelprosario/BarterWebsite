using BarterWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BarterWebsite.Controllers
{
   
    [BarterWebsite.Filters.InitializeSimpleMembership]
    public class NeedsListingController : Controller
    {
        //
        // GET: /Listing/

        public ActionResult Index()
        {
            NeedsRepo needs = new NeedsRepo();
            List<Need> list = needs.GetAll();
            list.Reverse();
            return View(list);
        }

        public ActionResult MakeAnOffer(int id)
        {

            NeedsRepo needs = new NeedsRepo();
            Need aNeed = needs.GetRecord(id);

          
            //It will load a list of offers  too.
            OfferForNeedRepo offers = new OfferForNeedRepo();
            List<OfferForNeed> list = offers.GetOffersForByNeedID(id);


            ViewBag.Offers = list;

            return View(aNeed);
        }

        private UserProfile getUserProfile()
        {
            string userName = User.Identity.Name;
            int recordID = WebSecurity.GetUserId(userName);
            UserProfileRepo users = new UserProfileRepo();
            UserProfile user = users.GetRecord(recordID);
            return user;
        }

        
      
        [HttpPost]
        public ActionResult MakeAnOffer(int id, FormCollection collection)
        {

            string offer = collection["txtOffer"];
            string strNeedID = collection["hidNeedId"];

            int needID = int.Parse(strNeedID);

            var currentUser = getUserProfile();
            

            OfferForNeed anOffer = new OfferForNeed();
            anOffer.Accepted_Flag = false;
            anOffer.Description = offer;
            anOffer.Need_ID = needID;
            anOffer.User_Making_Offer = currentUser.Email;
            OfferForNeedRepo offers = new OfferForNeedRepo();
            offers.AddRecord(anOffer);



            return RedirectToAction("MakeAnOffer", "NeedListing", needID);
           
        }


    }
}
