using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Front_end.Controllers
{
    public class MainController : Controller
    {
        

        public async Task<IActionResult> Index()
        {
           var projects = await new ProjectsRoutesController().GetProjects();
           return View(projects?.ToList());     
        }
    }
}
