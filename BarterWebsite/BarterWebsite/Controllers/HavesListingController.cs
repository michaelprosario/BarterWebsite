using BarterWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarterWebsite.Controllers
{
    public class HavesListingController : Controller
    {
        //
        // GET: /HavesListing/

        public ActionResult Index()
        {
            AvailableRepo avail = new AvailableRepo();
            List<Available> list = avail.GetAll();
            list.Reverse();
            return View(list);
        }

        //
        // GET: /HavesListing/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /HavesListing/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HavesListing/Create

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
        // GET: /HavesListing/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /HavesListing/Edit/5

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
        // GET: /HavesListing/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /HavesListing/Delete/5

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
    }
}
