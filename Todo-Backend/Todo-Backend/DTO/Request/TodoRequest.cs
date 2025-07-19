namespace Todo_Backend.Models.Request
{
    public class TodoRequest
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
