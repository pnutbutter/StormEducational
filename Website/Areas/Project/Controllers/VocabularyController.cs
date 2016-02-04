using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Areas.Project.Models.VocabularyData;
using Website.Controllers;

namespace Website.Areas.Project.Controllers
{
    public class VocabularyController : BaseController
    {

        // GET: Project/Vocabulary
        [Authorize]
        [HttpGet]
        public ActionResult Word(int? id)
        {
            Word data = new Word();

            //if(id.GetValueOrDefault(0)==1)
            //{
            //    data.VocabWord = "Peek";
            //    data.Sketch = "<svg width=\"640\" height=\"480\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\"><g><title>Layer 1</title><image xlink:href=\"http://data.whicdn.com/images/12451703/aaaaaaaaaaaaawn-cat-computer-cute-kitten-Favim.com-113870_large.jpg?1311637576\" id=\"svg_1\" height=\"413.00799\" width=\"621.99998\" y=\"3\" x=\"10\" /><text xml:space=\"preserve\" text-anchor=\"middle\" font-family=\"serif\" font-size=\"24\" id=\"svg_2\" y=\"458\" x=\"327\" stroke-width=\"0\" stroke=\"#000000\" fill=\"#000000\">Peek Vocab Word</text><circle id=\"svg_3\" r=\"22.18565\" cy=\"142.5\" cx=\"329.99999\" fill-opacity=\"0\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /><circle id=\"svg_4\" r=\"23.68565\" cy=\"137\" cx=\"270.50001\" fill-opacity=\"0\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /><path id=\"svg_5\" d=\"m295,179l43,-9l-41,22l-2,-13z\" stroke-linecap=\"null\" stroke-linejoin=\"null\" stroke-dasharray=\"null\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /><path id=\"svg_6\" d=\"m273,174l-3,16l-29,-24l32,8z\" stroke-linecap=\"null\" stroke-linejoin=\"null\" stroke-dasharray=\"null\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /></g></svg>";
            //} 
            //else if(id.GetValueOrDefault(0)==2)
            //    data.VocabWord = "Avalanche";
            if(id!=null)
            {
                Vocabulary item = db.Vocabularies.Where(a => a.VocabularyId == id.Value).FirstOrDefault();

                if (item.UserId != this.GetCurrentUser().UserId)
                    throw new ArgumentException("You do not have the rights to edit this word assignment.");

                data.Adjective = item.Adjective;
                data.Analogy = item.Analogy;
                data.Antonym = item.Antonym;
                data.Connotation = item.Connotation;
                data.Etymology = item.Etymology;
                data.FriendlyDefinition = item.FriendlyDefinition;
                data.NounPlural = item.NounPlural;
                data.NounSingular = item.NounSingular;
                data.PartOfSpeech = item.PartOfSpeech;
                data.Sentence = item.Sentance;
                data.Synonym = item.Synonym;
                data.VerbTenseHeSheIt = item.VerbTenseHeSheIt;
                data.VerbTenseI = item.VerbTenseI;
                data.VerbTenseThey = item.VerbTenseThey;
                data.VerbTenseTypeId = item.VerbTenseTypeId;
                data.VerbTenseWe = item.VerbTenseWe;
                data.VerbTenseYou = item.VerbTenseYou;
                data.VerbTenseYou2 = item.VerbTenseYou2;
                data.VocabularyId = item.VocabularyId;
                data.UserId = item.UserId;
                data.VocabWord = item.Word;
                data.Sketch = item.Sketch;
                //TODO: figure out word array
            }

            ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName");

            return View(data);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Word(Word data)
        {
            try
            {
                ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName");
                if (!this.ModelState.IsValid)
                {
                    return View(data);
                }
                Vocabulary item;

                if (data.VocabularyId != 0)
                {
                    item = db.Vocabularies.Where(v => v.VocabularyId == data.VocabularyId).FirstOrDefault();
                    if (item.UserId != this.GetCurrentUser().UserId)
                        throw new ArgumentException("You do not have the rights to edit this word assignment.");
                }
                else
                    item = new Vocabulary();

                item.Adjective = data.Adjective;
                item.Analogy = data.Analogy;
                item.Antonym = data.Antonym;
                item.Connotation = data.Connotation;
                item.Etymology = data.Etymology;
                item.FriendlyDefinition = data.FriendlyDefinition;
                item.NounPlural = data.NounPlural;
                item.NounSingular = data.NounSingular;
                item.PartOfSpeech = data.PartOfSpeech;
                item.Sentance = data.Sentence;
                item.Synonym = data.Synonym;
                item.VerbTenseHeSheIt = data.VerbTenseHeSheIt;
                item.VerbTenseI = data.VerbTenseI;
                item.VerbTenseThey = data.VerbTenseThey;
                item.VerbTenseTypeId = data.VerbTenseTypeId;
                item.VerbTenseWe = data.VerbTenseWe;
                item.VerbTenseYou = data.VerbTenseYou;
                item.VerbTenseYou2 = data.VerbTenseYou2;
                item.VocabularyId = data.VocabularyId;
                item.UserId = data.UserId;
                item.Word = data.VocabWord;
                item.Sketch = data.Sketch;
                //TODO: figure out word array and sketch

                item.ChangeBy = this.User.Identity.Name;
                item.ChangeDate = DateTime.Now;

                if (data.VocabularyId != 0)
                    db.Entry<Vocabulary>(item).State = EntityState.Modified;
                else
                {
                    item.UserId = this.GetCurrentUser().UserId;
                    item.CreateBy = this.User.Identity.Name;
                    item.CreateDate = DateTime.Now;
                    db.Vocabularies.Add(item);
                }
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


            return View(data);
        }
    }
}