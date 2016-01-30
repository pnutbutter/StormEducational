using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace Website.Areas.Project.Controllers
{
    public class VocabulariesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Project/Vocabularies
        [Authorize]
        public ActionResult Index()
        {
            var vocabularies = db.Vocabularies.Include(v => v.User).Include(v => v.VerbTenseType);
            return View(vocabularies.ToList());
        }

        // GET: Project/Vocabularies/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // GET: Project/Vocabularies/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName");
            ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName");
            return View();
        }

        // POST: Project/Vocabularies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VocabularyId,UserId,Word,PartOfSpeech,Etymology,Connotation,FriendlyDefinition,Adjective,NounSingular,NounPlural,VerbTenseTypeId,VerbTenseI,VerbTenseWe,VerbTenseYou,VerbTenseYou2,VerbTenseHeSheIt,VerbTenseThey,Synonym,Antonym,Sentance,Analogy,IsActive,CreateDate,CreateBy,ChangeDate,ChangeBy")] Vocabulary vocabulary)
        {
            if (ModelState.IsValid)
            {
                db.Vocabularies.Add(vocabulary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", vocabulary.UserId);
            ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName", vocabulary.VerbTenseTypeId);
            return View(vocabulary);
        }

        // GET: Project/Vocabularies/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", vocabulary.UserId);
            ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName", vocabulary.VerbTenseTypeId);
            return View(vocabulary);
        }

        // POST: Project/Vocabularies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VocabularyId,UserId,Word,PartOfSpeech,Etymology,Connotation,FriendlyDefinition,Adjective,NounSingular,NounPlural,VerbTenseTypeId,VerbTenseI,VerbTenseWe,VerbTenseYou,VerbTenseYou2,VerbTenseHeSheIt,VerbTenseThey,Synonym,Antonym,Sentance,Analogy,IsActive,CreateDate,CreateBy,ChangeDate,ChangeBy")] Vocabulary vocabulary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vocabulary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", vocabulary.UserId);
            ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName", vocabulary.VerbTenseTypeId);
            return View(vocabulary);
        }

        // GET: Project/Vocabularies/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // POST: Project/Vocabularies/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            db.Vocabularies.Remove(vocabulary);
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
