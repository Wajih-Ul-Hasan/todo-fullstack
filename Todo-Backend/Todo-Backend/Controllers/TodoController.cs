using Microsoft.AspNetCore.Mvc;
using Todo_Backend.Models.Request;
using Todo_Backend.Repository;

namespace Todo_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoService;

        public TodoController(ITodoRepository todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            try
            {
                var result = _todoService.GetTodos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching todos: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoRequest request)
        {
            try
            {
                var success = _todoService.AddTodo(request);
                if (success)
                    return Ok(new { message = "Todo added successfully." });

                return BadRequest(new { message = "Failed to add todo." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding todo: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateTodo([FromBody] TodoRequest request)
        {
            try
            {
                var success = _todoService.UpdateTodo(request);
                if (success)
                    return Ok(new { message = "Todo updated successfully." });

                return NotFound(new { message = "Todo not found for update." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating todo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            try
            {
                var success = _todoService.DeleteTodo(id);
                if (success)
                    return Ok(new { message = "Todo deleted successfully." });

                return NotFound(new { message = "Todo not found for deletion." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting todo: {ex.Message}");
            }
        }
    }
}
