using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseProject.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : Controller
    {
        private readonly TodoContext todoContext;

        /// <summary>
        /// set context for todo Item
        /// </summary>
        /// <param name="context"></param>
        public TodoItemsController(TodoContext context)
        {
            todoContext = context;
        }

        /// <summary>
        ///Method for get item by id
        /// </summary>
        /// <param name="id">model id</param>
        /// <returns>item by id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(Guid id)
        {
            var todoItem = await todoContext.TodoItems.FindAsync(id);

            if (todoItem == null)
                return NotFound();

            return DTOConverter.ConvertFromDatabaseToDtoItem(todoItem);
        }

        /// <summary>      
        /// Post method for create new item
        /// </summary>
        /// <param name="todoItemDto">model</param>
        /// <returns>new item</returns>
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoItemDto)
        {
            var todoItem = DTOConverter.ConvertFromDtoToDatabaseItem(todoItemDto);
            todoContext.TodoItems.Add(todoItem);
            await todoContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItemDto.Id }, todoItemDto);
        }
        
        /// <summary>
        /// Update item by id
        /// </summary>
        /// <param name="id">model id</param>
        /// <param name="todoItem">model</param>
        /// <returns>updated model</returns>
        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
                return BadRequest();

            var todoItem = DTOConverter.ConvertFromDtoToDatabaseItem(todoItemDTO);

            todoContext.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await todoContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id">model id</param>
        /// <returns>deleted model</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var todoItem = await todoContext.TodoItems.FindAsync(id);
            if (todoItem == null)
                return NotFound();

            todoContext.TodoItems.Remove(todoItem);
            await todoContext.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Is item with guid exists
        /// </summary>
        /// <param name="id">model id</param>
        /// <returns></returns>
        private bool TodoItemExists(Guid id)
        {
           return  todoContext.TodoItems.Any(t => t.Id.Equals(id));
        }
    }
}
