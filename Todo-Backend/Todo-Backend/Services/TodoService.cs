using Todo_Backend.Domain;
using Todo_Backend.Models.Request;
using Todo_Backend.Models.Response;
using Todo_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Todo_Backend.Entities;

namespace Todo_Backend.Services
{
    public class TodoService : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public bool AddTodo(TodoRequest todo)
        {
            var entity = new Todo
            {
                Task = todo.Task,
                Date = todo.Date
            };

            _context.Todos.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteTodo(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null) return false;

            _context.Todos.Remove(todo);
            return _context.SaveChanges() > 0;
        }

        public TodoResponseList GetTodos()
        {
            var todos = _context.Todos
                .AsNoTracking()
                .Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Task = t.Task,
                    Date = t.Date
                })
                .ToList();

            return new TodoResponseList
            {
                TodoResponses = todos
            };
        }

        public bool UpdateTodo(TodoRequest todo)
        {
            var existing = _context.Todos.Find(todo.Id);
            if (existing == null) return false;

            existing.Task = todo.Task;
            existing.Date = todo.Date;

            _context.Todos.Update(existing);
            return _context.SaveChanges() > 0;
        }
    }
}
