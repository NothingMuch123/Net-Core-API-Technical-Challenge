using System.ComponentModel.DataAnnotations;

namespace Technical_Challenge.Models.API
{
    public class CreateUniversityRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        public List<string>? Webpages { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class UpdateUniversityRequest
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string>? Webpages { get; set; }
        public bool? IsActive { get; set; } = true;
    }

    public class GetUniversityRequest : PaginationRequest
    {
        public string? Name { get; set; } = null;
        public string? Country { get; set; } = null;
        public bool? IsActive { get; set; } = true;
    }
}
