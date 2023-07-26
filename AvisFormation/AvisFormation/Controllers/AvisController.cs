using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvisFormation.Data.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvisFormationUI.Controllers
{
    public class AvisController : Controller
    {
        // GET: /<controller>/
        public IActionResult LeaveAComment(string nameSeo)
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult SaveComment(string commentaire, string nom, string note)
        {
            Avi newAvis = new Avi();
            newAvis.DateAvis = DateTime.Now;
            newAvis.Description = commentaire;
            newAvis.IdFormation = 1;
            newAvis.Nom = nom;

            newAvis.Note = 5;



            using(var context = new AvisFormationdbContext())
            {

            }

            return View();
        }
    }
}

