using System.ComponentModel.DataAnnotations.Schema;

namespace Note_Taking_App.Models
{
    public class Note
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

       
        public bool IsDeactive { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        









    }
}
