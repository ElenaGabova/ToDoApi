namespace TodoApi.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Item guid as Id (key)
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Item Name
        /// </summary>
        public string Name { get;private set; }

        /// <summary>
        /// Sign Is item complete
        /// </summary>
        public bool IsComplete { get;private set; }

        //Constructor for new item
        public TodoItem(string name, bool isComplete)
        {
            //Check empty name
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Item name is null");

            Id = new Guid();
            Name = name;
            IsComplete = isComplete;
        }
       

    }
}
