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
    public class TradeController : Controller
    {

        public ActionResult MyGoodsAndServices()
        {
            UserProfile user = getUserProfile();

            var availables = new AvailableRepo();

            List<Available> list = availables.GetAvailablesByEmail(user.Email);

            return View(list);
        }

        private UserProfile getUserProfile()
        {
            string userName = User.Identity.Name;
            int recordID = WebSecurity.GetUserId(userName);
            UserProfileRepo users = new UserProfileRepo();
            UserProfile user = users.GetRecord(recordID);
            return user;
        }


        public ActionResult ShareGoodsAndServices()
        {
            //Get categories ....
            var categories = new CategoriesRepo();
            var cats = categories.GetAll();

            ViewBag.Categories = cats;

            var avaiable = new BarterWebsite.Models.Available();
            avaiable.Closed_Flag = false;
            avaiable.Description = "";
            avaiable.Category = "";
            return View(avaiable);
        }


        public ActionResult Delete(int id)
        {
            var profile = getUserProfile();

            var availables = new AvailableRepo();
            var available = availables.GetRecord(id);

            if (available.User_Email_Avl != profile.Email)
                throw new ApplicationException("You can only delete records that belong to you.");

            availables.DeleteRecord(id);

            return RedirectToAction("MyGoodsAndServices");
        }

        [HttpPost]
        public ActionResult ShareGoodsAndServices(FormCollection collection)
        {

                var availables = new AvailableRepo();

                // get my email address ....
                UserProfile user = getUserProfile();

                // get category ...
                string category = collection["category"];
                string description = collection["description"];

                var record = new Available();

                record.User_Email_Avl = user.Email;
                record.Category = category;
                record.Description = description;
                record.Closed_Flag = false;
                record.City = Constants.CITY;

                availables.AddRecord(record);

                return RedirectToAction("MyGoodsAndServices");
            
        }

        /*
        //
        // GET: /Trade/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Trade/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Trade/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trade/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Trade/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Trade/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Trade/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Trade/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        */
    }
}
