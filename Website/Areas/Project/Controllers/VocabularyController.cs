using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Project.Models.VocabularyData;

namespace Website.Areas.Project.Controllers
{
    public class VocabularyController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Project/Vocabulary
        public ActionResult Word(int? id)
        {
            Word data = new Word();

            if(id.GetValueOrDefault(0)==1)
                data.VocabWord = "Peek";
            else if(id.GetValueOrDefault(0)==2)
                data.VocabWord = "Avalanche";

            ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName");

            return View(data);
        }
    }
}