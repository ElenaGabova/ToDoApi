using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoItemDTO
    {
        /// <summary>
        /// Item guid as Id (key)
        /// </summary>
        public Guid Id { get;  set; }

        /// <summary>
        /// Item Name
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// Sign Is item complete
        /// </summary>
        public bool IsComplete { get;  set; }

        public TodoItemDTO() { }

        //Constructor for new item
        public TodoItemDTO(Guid id, string name, bool isComplete)
        {
            if (ModelIsValid())
            {
                Id = id;
                Name = name;
                IsComplete = isComplete;
            }

        }

        //Constructor for new item with new guid
        public TodoItemDTO(string name, bool isComplete):this(new Guid(), name, isComplete)
        {
        }

        /// <summary>
        /// Check model is Valid
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool ModelIsValid()
        {
            //Check empty id
            if (this.Id.Equals(Guid.Empty))
                throw new ArgumentNullException("Item id is null");

            //Check empty name
            if (string.IsNullOrEmpty(this.Name))
                throw new ArgumentNullException("Item name is null");

            //Check empty isComplete
            if (this.IsComplete == null)
                throw new ArgumentNullException("Item isComplete  is null");

            return true;
        }
    }
}
