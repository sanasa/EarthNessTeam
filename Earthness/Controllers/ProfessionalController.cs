using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using BusinessLayerEarthness.Implementation;
using BusinessLayerEarthness.Facade;

namespace Earthness.Controllers
{
    public class ProfessionalController : Controller
    {
        private IProfessionalManager manager = new ProfessionalManager(new masterEntities());

        // GET: Professional
        public ActionResult StartCompany()
        {
            ViewBag.register = TempData["registersuccess"];
            Professional pro = new Professional();
            return View(@"~\Views\StartCompany.cshtml",pro);
        }

        public ActionResult Homepage()
        {
            return View();
        }

        // GET: Professional/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Professional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professional/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="CompanyId")]Professional pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    manager.InsertProfessional(pro);
                    manager.Save();

                }
                TempData["registersuccess"] = "Thank you for your registration :D please log in to access your home page.";
                return RedirectToAction("StartCompany");
            }
            catch
            {
                return RedirectToAction("StartCompany");
            }
        }

        // GET: Professional/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Professional/Edit/5
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

        // GET: Professional/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Professional/Delete/5
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


        public ActionResult Login(Professional model)
        {
            {
                Professional proff = manager.checkLogIn(model.CompanyEmail, model.Password);
                if (proff != null)
                {

                    return RedirectToAction("Homepage");
                }
                ViewBag.logerror = "Please verify your e-mail or password !";
            }


            return View(@"~\Views\StartCompany.cshtml");
        }
    }
}
