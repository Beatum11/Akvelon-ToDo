using System.ComponentModel.DataAnnotations;

namespace Akv_API.Models
{
    public class TaskItem
    {
        #region Fields

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ProjectName { get; set; }

        public string? Status { get; set; }

        public string? Description { get; set; }

        public int Priority { get; set; }

        #endregion


        #region Constructor

        public TaskItem(int id, string name, string projectName, string status, 
                        string description, int priority)
        {
            Id = id;
            Name = name;
            ProjectName = projectName;
            Status = status;
            Description = description;
            Priority = priority;
        }

        #endregion

    }
}
