using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Front_end.Controllers;
using System.Dynamic;

namespace Front_end.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddProject(Project project)
        {
            await new ProjectsRoutesController().PostProject(project);
            return RedirectToAction("Index", "Main");
        }

        public async Task<IActionResult> ShowProject(int id)
        {
            var neededProj = await new ProjectsRoutesController().GetProject(id);
            var taskItems = await new TasksRoutesController().GetTaskItems();
            var neededTasks = taskItems.Where(t => t.ProjectName == neededProj.Name).
                             ToList();

            dynamic myModel = new ExpandoObject();
            myModel.Proj = neededProj;
            myModel.TaskItems = neededTasks;

            return View(myModel);
        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            await new ProjectsRoutesController().DeleteProject(id);
            return RedirectToAction("Index", "Main");
        }
    }
}
