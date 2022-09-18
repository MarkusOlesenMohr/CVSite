using CVSite.Application.CV.Queries;
using CVSite.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CVSite.Web.Controllers
{
    public class CVController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CVController(ILogger logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        // GET: CVController
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllCVsQuery.Query());
            return View(result);
        }

        // GET: CVController/Details/5
        public ActionResult Details(int id)
        {
            _mediator.Send(new GetAllCVsQuery.Query());
            return View();
        }

        // GET: CVController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CVController/Create
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

        // GET: CVController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CVController/Edit/5
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

        // GET: CVController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CVController/Delete/5
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
