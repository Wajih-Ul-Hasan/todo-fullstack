using Todo_Backend.Models.Request;
using Todo_Backend.Models.Response;

namespace Todo_Backend.Repository
{
    public interface ITodoRepository
    {
        bool AddTodo(TodoRequest todo);
        bool UpdateTodo(TodoRequest todo);
        bool DeleteTodo(int id);
        TodoResponseList GetTodos();
    }
}
