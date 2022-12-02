namespace Note_Taking_App.Models
{
    public class Note
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDeactive { get; set; }
    }
}
