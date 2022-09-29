using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using be.MbDevelopment.Greenmaster.Data;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using be.MbDevelopment.Greenmaster.Tests.TestData;

namespace be.MbDevelopment.Greenmaster.Web.Controllers
{
    public class ArboretumController : Controller
    {
        // GET: ArboretumController
        public ActionResult Index()
        {
            return View(InMemoryGarden.Species);
        }

        // GET: ArboretumController/Details/5
        public ActionResult Details(string id)
        {
            var firstOrDefault = InMemoryGarden.Species.First(specie => specie.Id.Equals(Guid.Parse(id)));
            return View(firstOrDefault);
        }

        /*// GET: ArboretumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArboretumController/Create
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

        // GET: ArboretumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArboretumController/Edit/5
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

        // GET: ArboretumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArboretumController/Delete/5
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
        }*/
    }
}
