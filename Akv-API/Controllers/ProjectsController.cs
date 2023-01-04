using Akv_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Akv_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        #region Basic set-up

        private readonly Context Context;

        public ProjectsController(Context context)
        {
            Context = context;
        }

        #endregion


        #region GET

        // GET: api/<ProjectsController>
        [HttpGet]
        public List<Project> Get()
        {
            return Context.Projects.ToList();
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return Context.Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        #endregion

        #region POST

        // POST api/<ProjectsController>
        [HttpPost]
        public void Post(Project project)
        {
            Context.Projects.Add(project);
            Context.SaveChanges();
        }

        #endregion

        #region PUT

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, Project project)
        {
            var neededProject = Context.Projects.Where(p => p.Id == id).FirstOrDefault();

            if (neededProject != null)
            Context.Projects.Remove(neededProject);

            Context.Projects.Add(project);
            Context.SaveChanges();
        }

        #endregion

        #region DELETE

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var project = Context.Projects.Where(p => p.Id == id).FirstOrDefault();

            if (project != null)
            Context.Projects.Remove(project);

            Context.SaveChanges();
        }

        #endregion
    }
}
