using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvisFormation.Data.Data;
using AvisFormationUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvisFormationUI.Controllers
{
    public class FormationController : Controller
    {
      

        // Get all formations
        public IActionResult AllFromations()
        {
            List<Formation> listFromations = new List<Formation>();

            //We use using because it's we clause the connection connection
            //of database after "using"
            using (var context = new AvisFormationdbContext()) {
                listFromations = context.Formations.ToList();
            }

            return View(listFromations);
        }


        // Get all details about formation
        public IActionResult DetailsFromation(string nameSeo)
        {
            var formationWithReviews = new FormationAvecAvis();

            using (var context = new AvisFormationdbContext())
            {
                //firstOrDefault will send null if it's not find
                var findFormationByNameSeo = context.Formations.Where(f=>f.NomSeo == nameSeo).FirstOrDefault();
                List<Avi> listFromations = new List<Avi>();

                if (findFormationByNameSeo == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                formationWithReviews.FormationNom = findFormationByNameSeo.Nom;
                formationWithReviews.FormationDescription = findFormationByNameSeo.Description;
                formationWithReviews.FormationNomSeo = nameSeo;
                formationWithReviews.FormationUrl = findFormationByNameSeo.Url;
                formationWithReviews.Avis = context.Avis.Where(a=>a.IdFormation == findFormationByNameSeo.Id).ToList();
                if (formationWithReviews.Avis.Count > 0)
                    formationWithReviews.Note = formationWithReviews.Avis.Average(a => a.Note);
                formationWithReviews.NombreAvis = formationWithReviews.Avis.Count;

            }

            return View(formationWithReviews);
        }
    }
}

