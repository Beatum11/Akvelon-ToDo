using System.ComponentModel.DataAnnotations;

namespace Akv_API.Models
{
    public class Project
    {

        #region Fields

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CurrentState { get; set; }

        public int Priority { get; set; }

        #endregion


        #region Constructor

        public Project(int id, string name, DateTime createdDate, string currentState, 
                        int priority)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
            CurrentState = currentState;
            Priority = priority;
        }

        #endregion


    }
}
