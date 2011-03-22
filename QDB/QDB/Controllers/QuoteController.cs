using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QDB.Controllers
{
    public class QuoteController : Controller
    {
        //
        // GET: /Quote/

        //[AcceptVerbs(new string[] { "HttpVerbs.Get", "HttpVerbs.Delete" })
        [HttpGet]
        public ActionResult Index(int? id)
        {
            
            QuoteDB qdb = new QuoteDB();

            if (!id.HasValue)
                id = 1;

            ViewData.Model = qdb.GetQuote(id.Value);

            return View();
        }

        [ActionName("Index")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            ViewData["delete"] = "DELETE APPLIED TO " + id;
            return View();
        }

        public ActionResult Random()
        {
            return View();
        }

        //
        // GET: /Quote/Submit

        public ActionResult Submit()
        {
            return View();
        } 

        //
        // POST: /Quote/Submit

        [HttpPost]
        public ActionResult Submit(FormCollection collection)
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
        // GET: /Quote/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Quote/Edit/5

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
    }
}
