using System.ComponentModel.DataAnnotations;

namespace Front_end.Models
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

        #region Constructors

        public TaskItem()
        {

        }


        public TaskItem(string name, string projectName, string status,
                        string description, int priority)
        {
            Name = name;
            ProjectName = projectName;
            Status = status;
            Description = description;
            Priority = priority;
        }

        #endregion
    }
}
