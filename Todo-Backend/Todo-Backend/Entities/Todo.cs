namespace Todo_Backend.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
