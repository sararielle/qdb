using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QDB.Controllers
{
    public class QuotesController : Controller
    {
        //
        // GET: /Quotes/

        public ActionResult Index()
        {
            QuoteDB qdb = new QuoteDB();
            ViewData.Model = qdb.GetQuotes().Reverse();
            return View();
        }

        public ActionResult Browse()
        {
            QuoteDB qdb = new QuoteDB();
            ViewData.Model = qdb.GetQuotes();
            return View();
        }

        public ActionResult Random()
        {
            return View();
        }

        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Search(string query)
        {
            if(query != null)
                ViewData["search"] = query;
            return View();
        }
    }
}
