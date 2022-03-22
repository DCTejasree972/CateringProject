using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class CateringsController : Controller
    {
        private CateringDatabaseContext db = new CateringDatabaseContext();

        // GET: Caterings
        public ActionResult Index()
        {
            var ca = db.ca.Include(c => c.category);
            return View(ca.ToList());
        }
        public ActionResult MenuList(int id)
        {
            return View(db.ca.Where(x => x.categID == id).Include(x => x.category).ToList());
        }

        // GET: Caterings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catering catering = db.ca.Find(id);
            if (catering == null)
            {
                return HttpNotFound();
            }
            return View(catering);
        }

        // GET: Caterings/Create
        public ActionResult Create()
        {
            ViewBag.categID = new SelectList(db.c, "id", "section");
            return View();
        }

        // POST: Caterings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,categID,name,people,items,image,cost")] Catering catering, HttpPostedFileBase[] file)
        {
            if (file == null)
            {
                ModelState.AddModelError("file", "Please Upload Your file");
                ViewBag.message = "Please Pick a file for upload";
                return View();
            }
            else
            {
                int MaxContentLength = 1024 * 1024 * 3;
                string[] AllowedFileExtensions = new string[] { ".jpg",".jpeg", ".txt", ".gif", ".png", ".pdf" };
                foreach (HttpPostedFileBase files in file)
                {
                    if (files.ContentLength > 0)
                    {
                        if (!AllowedFileExtensions.Contains(files.FileName.Substring(files.FileName.LastIndexOf('.'))))
                        {
                            ModelState.AddModelError("File", "Please use file of type:" + string.Join(",", AllowedFileExtensions));
                            ViewBag.message = "wrong file type";
                            return View();


                        }
                        else if (files.ContentLength > MaxContentLength)
                        {
                            ModelState.AddModelError("File", "Your file is too large,maximum allowed file range is :" + MaxContentLength + "Mb");
                            ViewBag.message = "Your file is too large,maximum allowed file range is: " + MaxContentLength + "Mb";
                            return View();
                        }
                        else
                        {
                            Catering ca = new Catering();
                            ca.name = catering.name;
                            ca.categID = catering.categID;
                            ca.category = catering.category;
                            ca.people = catering.people;
                            ca.items = catering.items;
                            ca.cost = catering.cost;
                            var filename = Path.GetFileName(files.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/"), filename);
                            files.SaveAs(path);
                            ca.image = "~/Images/" + filename;
                            db.Entry(ca).State = EntityState.Added;
                            db.SaveChanges();
                            ViewBag.UploadStatus = file.Count().ToString() + "files succesfully uploaded";
                            ViewBag.message = "files succesfully uploaded";


                        }
                    }
                }

            }


            return View(catering);
        }

        // GET: Caterings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catering catering = db.ca.Find(id);
            if (catering == null)
            {
                return HttpNotFound();
            }
            ViewBag.categID = new SelectList(db.c, "id", "section", catering.categID);
            return View(catering);
        }

        // POST: Caterings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,categID,name,people,items,image,cost")] Catering catering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categID = new SelectList(db.c, "id", "section", catering.categID);
            return View(catering);
        }

        // GET: Caterings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catering catering = db.ca.Find(id);
            if (catering == null)
            {
                return HttpNotFound();
            }
            return View(catering);
        }

        // POST: Caterings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catering catering = db.ca.Find(id);
            db.ca.Remove(catering);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
