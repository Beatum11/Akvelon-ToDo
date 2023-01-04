using Front_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace Front_end.Controllers
{
    public class TasksController : Controller
    {

        #region EDIT

        public async Task<IActionResult> EditTaskPanel(int id)
        {
            var taskItem = await new TasksRoutesController().GetTaskItem(id);
            return View(taskItem);
        }

        public async Task<IActionResult> EditTask(int id, TaskItem taskItem)
        {
            taskItem.Status = "Active";
            await new TasksRoutesController().EditTaskItem(id, taskItem);
            return RedirectToAction("Index", "Main");
        }

        #endregion


        public IActionResult CreateTaskPanel()
        {
            TaskItem taskItem = new TaskItem();
            return View(taskItem);
        }

        public async Task<IActionResult> AddTask(TaskItem taskItem)
        {
            taskItem.Status = "Active";
            await new TasksRoutesController().PostTaskItem(taskItem);
            return RedirectToAction("Index", "Main");
        }

        public async Task<IActionResult> DeleteTask(int id)
        {
            await new TasksRoutesController().DeleteTaskItem(id);
            return RedirectToAction("Index", "Main");
        }
    }
}
