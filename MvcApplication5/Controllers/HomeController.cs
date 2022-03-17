using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;

namespace MvcApplication5.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        testEntities1 ts = new testEntities1();
        public ActionResult Index()
        {
            var db = ts.tasks.ToList();
            List<form> fm = new List<form>();
            foreach (var i in db) {
                form f = new form();
                f.id = i.id;
                f.name = i.name;
                fm.Add(f);
            }
            return View(fm);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            form f = new form();
            return View(f);
        } 

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(form f)
        {
            try
            {
                // TODO: Add insert logic here
                task t = new task();
                t.name = f.name;
                ts.tasks.AddObject(t);
                ts.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            form f = new form();
            var t = ts.tasks.Where(x => x.id == id).SingleOrDefault();
            f.id = t.id;
            f.name = t.name;
            return View(f);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, form f)
        {
            try
            {
                // TODO: Add update logic here
                var pv = ts.tasks.Where(x => x.id == id).SingleOrDefault();
                pv.name = f.name;
                ts.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
            var pv = ts.tasks.Where(x => x.id == id).SingleOrDefault();
            ts.DeleteObject(pv);
            ts.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Home/Delete/5

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
