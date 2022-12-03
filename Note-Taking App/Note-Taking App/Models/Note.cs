namespace Note_Taking_App.Models
{
    public class Note
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        
        public bool IsCompleted { get; set; }
        public bool IsInProgress { get; set; }
    }
}
