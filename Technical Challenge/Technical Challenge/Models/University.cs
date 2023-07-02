using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Technical_Challenge.Models.API;

namespace Technical_Challenge.Models
{
    public class University
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string>? Webpages { get; set; }
        public bool IsBookmark { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Empty constructor for migrations
        private University() { }

        public University(CreateUniversityRequest req)
        {
            Name = req.Name;
            Country = req.Country;
            Webpages = req.Webpages;
            Created = DateTime.UtcNow;
            IsActive = req.IsActive;
        }
    }
}
