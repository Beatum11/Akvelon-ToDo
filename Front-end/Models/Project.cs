using System.ComponentModel.DataAnnotations;

namespace Front_end.Models
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


        #region Constructors

        public Project()
        {

        }

        public Project(string name, DateTime createdDate, string currentState,
                        int priority)
        {
            Name = name;
            CreatedDate = createdDate;
            CurrentState = currentState;
            Priority = priority;
        }

        #endregion

    }
}
