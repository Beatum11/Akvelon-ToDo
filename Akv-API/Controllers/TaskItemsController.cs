using Akv_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akv_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        #region Basic set-up

        public readonly Context Context;

        public TaskItemsController(Context context)
        {
            Context = context;
        }

        #endregion


        #region GET

        // GET: api/<TaskItemsController>
        [HttpGet]
        public List<TaskItem> Get()
        {
            return Context.TaskItems.ToList();
        }

        // GET api/<TaskItemsController>/5
        [HttpGet("{id}")]
        public TaskItem Get(int id)
        {
            return Context.TaskItems.Where(t => t.Id == id).FirstOrDefault();
        }

        #endregion

        #region POST

        // POST api/<TaskItemsController>
        [HttpPost]
        public void Post(TaskItem taskItem)
        {
            Context.TaskItems.Add(taskItem);
            Context.SaveChanges();
        }

        #endregion

        #region PUT

        // PUT api/<TaskItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, TaskItem taskItem)
        {
            //Removing previous version of TaskItem
            var neededTask = Context.TaskItems.Where(p => p.Id == id).FirstOrDefault();

            if (neededTask != null)
                Context.TaskItems.Remove(neededTask);

            //Adding a new version
            Context.TaskItems.Add(taskItem);
            Context.SaveChanges();
        }

        #endregion

        #region DELETE

        // DELETE api/<TaskItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = Context.TaskItems.Where(t => t.Id == id).FirstOrDefault();

            if(task != null)
            Context.TaskItems.Remove(task);

            Context.SaveChanges();
        }

        #endregion
    }
}
