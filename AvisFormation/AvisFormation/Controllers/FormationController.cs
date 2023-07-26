using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvisFormation.Data.Data;
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
    }
}

