namespace Todo_Backend.Models.Response
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
