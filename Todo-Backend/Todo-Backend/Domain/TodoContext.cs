using Microsoft.EntityFrameworkCore;
using Todo_Backend.Entities;

namespace Todo_Backend.Domain
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
