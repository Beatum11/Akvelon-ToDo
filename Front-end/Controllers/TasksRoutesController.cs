using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Front_end.Controllers
{
    public class TasksRoutesController : Controller
    {
        #region GET
        public async Task<List<TaskItem>> GetTaskItems()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync
                    ("https://localhost:7244/api/TaskItems");

                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();
                var taskItems =
                    JsonConvert.DeserializeObject<List<TaskItem>>(text);

                if (taskItems != null)
                    return taskItems;
            }

            return null;
        }

        public async Task<TaskItem> GetTaskItem(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync
                    ("https://localhost:7244/api/TaskItems/" + id);
                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();
                var taskItem = JsonConvert.DeserializeObject<TaskItem>(text);

                if (taskItem != null)
                    return taskItem;
            }
            return null;
        }

        #endregion

        #region POST
        public async Task PostTaskItem(TaskItem taskItem)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var newTaskJson = JsonConvert.SerializeObject(taskItem);
                var payload = new StringContent(newTaskJson, Encoding.UTF8,
                                                               "application/json");
                await httpClient.PostAsync("https://localhost:7244/api/TaskItems", payload);
            }
        }

        #endregion

        #region PUT

        public async Task EditTaskItem(int id, TaskItem taskItem)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var newTask = new TaskItem(taskItem.Name, taskItem.ProjectName, taskItem.Status,
                    taskItem.Description, taskItem.Priority);

                var newTaskJson = JsonConvert.SerializeObject(newTask);
                var payload = new StringContent(newTaskJson,
                                  Encoding.UTF8, "application/json");

                await httpClient.PutAsync("https://localhost:7244/api/TaskItems/" +
                                          id, payload);
            }
        }


        #endregion

        #region DELETE
        public async Task DeleteTaskItem(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync("https://localhost:7244/api/TaskItems/" + id);
            }
        }

        #endregion
    }
}
