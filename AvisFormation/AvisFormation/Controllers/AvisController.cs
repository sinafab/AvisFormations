using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AvisFormation.Data.Data;
using AvisFormationUI.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvisFormationUI.Controllers
{
    public class AvisController : Controller
    {
        // GET: /<controller>/
        public IActionResult LeaveAComment(string nameSeo)
        {
            var comment = new LeaveAComment();
            comment.NomSeo = nameSeo;
            using (var context = new AvisFormationdbContext())
            {
                var findFormationBySeo = context.Formations.FirstOrDefault(f => f.NomSeo == nameSeo);
                if (findFormationBySeo == null)
                    return RedirectToAction("Index", "Home");
                comment.FormationName = findFormationBySeo.Nom;
            }
            return View(comment);
        }

        // GET: /<controller>/
        public IActionResult SaveComment(string commentaire, string nom, string note, string nomSeo)
        {
            Avi newComment = new Avi();
            newComment.DateAvis = DateTime.Now;
            newComment.Description = commentaire;
            newComment.Nom = nom;


            double dNote = 0;

            if(!double.TryParse(note,NumberStyles.Any, CultureInfo.InvariantCulture, out dNote))
            {
                throw new Exception("impossible de parser la note "+note);
            }
            newComment.Note = dNote;
            using(var context = new AvisFormationdbContext())
            {
                var findFormationBySeo = context.Formations.FirstOrDefault(f => f.NomSeo == nomSeo);

                if(findFormationBySeo == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                newComment.IdFormation = findFormationBySeo.Id;
                context.Avis.Add(newComment);
                context.SaveChanges();
            }

            return RedirectToAction("DetailsFromation","Formation", new {nameSeo = nomSeo});
        }
    }
}

