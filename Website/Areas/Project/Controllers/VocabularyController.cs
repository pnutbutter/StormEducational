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
            {
                data.VocabWord = "Peek";
                data.Sketch = "<svg width=\"640\" height=\"480\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\"><g><title>Layer 1</title><image xlink:href=\"http://data.whicdn.com/images/12451703/aaaaaaaaaaaaawn-cat-computer-cute-kitten-Favim.com-113870_large.jpg?1311637576\" id=\"svg_1\" height=\"413.00799\" width=\"621.99998\" y=\"3\" x=\"10\" /><text xml:space=\"preserve\" text-anchor=\"middle\" font-family=\"serif\" font-size=\"24\" id=\"svg_2\" y=\"458\" x=\"327\" stroke-width=\"0\" stroke=\"#000000\" fill=\"#000000\">Peek Vocab Word</text><circle id=\"svg_3\" r=\"22.18565\" cy=\"142.5\" cx=\"329.99999\" fill-opacity=\"0\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /><circle id=\"svg_4\" r=\"23.68565\" cy=\"137\" cx=\"270.50001\" fill-opacity=\"0\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /><path id=\"svg_5\" d=\"m295,179l43,-9l-41,22l-2,-13z\" stroke-linecap=\"null\" stroke-linejoin=\"null\" stroke-dasharray=\"null\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /><path id=\"svg_6\" d=\"m273,174l-3,16l-29,-24l32,8z\" stroke-linecap=\"null\" stroke-linejoin=\"null\" stroke-dasharray=\"null\" stroke-width=\"5\" stroke=\"#000000\" fill=\"#000000\" /></g></svg>";
            } 
            else if(id.GetValueOrDefault(0)==2)
                data.VocabWord = "Avalanche";

            ViewBag.VerbTenseTypeId = new SelectList(db.VerbTenseTypes, "VerbTenseTypeId", "VerbTenseTypeName");

            return View(data);
        }
    }
}