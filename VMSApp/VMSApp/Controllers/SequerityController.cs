using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VMSApp.Models;

namespace VMSApp.Controllers
{
    public class SequerityController : Controller
    {
        // GET: Sequerity


        private readonly ILogger<SequerityController> _logger;

        public SequerityController(ILogger<SequerityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sequerity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sequerity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sequerity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sequerity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Signup(Visitor visitor)
        {
            VisitorDbManager.Insert(visitor);

            return View();
        }


        public ActionResult Created()
        {
            return Ok(new { message = "Visitor created" });
        }

        public ActionResult UpdateVisitor()
        {
            return View();
        }
        public ActionResult InVisitor()

        {
            List<Visitor> allvisitor = VisitorDbManager.GetAllVisitorIn();
            this.ViewData["allvisitor"] = allvisitor;
            return View();
        }
        public ActionResult OutVisitor()
        {
            return View();
        }





        // POST: Sequerity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sequerity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sequerity/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
