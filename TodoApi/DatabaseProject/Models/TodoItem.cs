using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class TodoItem
    {

        /// <summary>
        /// Item guid as Id (key)
        /// </summary>
        [Key]
        public Guid Id { get;  set; }

        /// <summary>
        /// Item Name
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// Sign Is item complete
        /// </summary>
        public bool IsComplete { get;  set; }
    }
}
