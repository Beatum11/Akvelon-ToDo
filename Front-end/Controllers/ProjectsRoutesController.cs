using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Front_end.Controllers
{
    public class ProjectsRoutesController : Controller
    {
        #region GET
        public async Task<List<Project>> GetProjects()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync
                    ("https://localhost:7244/api/Projects");

                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<Project>>(text);

                if (projects != null)
                    return projects;
            }

            return null;
        }

        public async Task<Project> GetProject(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync
                    ("https://localhost:7244/api/Projects/" + id);
                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();
                var project = JsonConvert.DeserializeObject<Project>(text);

                if(project != null)
                return project;
            }
            return null;
        }

        #endregion

        #region POST
        public async Task PostProject(Project project)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var newProjectJson = JsonConvert.SerializeObject(project);
                var payload = new StringContent(newProjectJson, Encoding.UTF8,
                                                               "application/json");
                await httpClient.PostAsync("https://localhost:7244/api/Projects", payload);
            }
        }

        #endregion

        #region DELETE
        public async Task DeleteProject(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync("https://localhost:7244/api/Projects/" + id);
            }
        }

        #endregion


    }
}
