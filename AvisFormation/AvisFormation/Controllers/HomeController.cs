using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AvisFormation.Models;
using AvisFormation.Data.Data;

namespace AvisFormation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //We use using because it's we clause the connection connection
        //of database after using
        using (var context = new AvisFormationdbContext())
        {
            var person = context.Avis;
            var thomas = person.Where(personne => personne.Nom == "Thomas");
            var v = thomas.ToList();
            var listeFromations = context.Formations.ToList();
        }
        ViewBag.Message = "page d'acceuil";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

