using TodoApi.Models;
using DatabaseProject.Models;

namespace TodoApi
{
    public static class DTOConverter
    {
        /// <summary>
        /// Convert from DTO to database model
        /// </summary>
        /// <param name="todoItem">DTO model</param>
        /// <returns></returns>
        public static TodoItem ConvertFromDtoToDatabaseItem(TodoItemDTO todoItem)
        {
            if (todoItem.ModelIsValid())
            {
                return new TodoItem()
                {
                    Id = todoItem.Id,
                    Name = todoItem.Name,
                    IsComplete = todoItem.IsComplete
                };
            }

            return null;

        }

        /// <summary>
        /// Convert from database to DTO model
        /// </summary>
        /// <param name="todoItem">database model</param>
        /// <returns></returns>
        public static TodoItemDTO ConvertFromDatabaseToDtoItem(TodoItem todoItem)
        {
            return new TodoItemDTO(todoItem.Id, todoItem.Name, todoItem.IsComplete);
        }
    }
}
