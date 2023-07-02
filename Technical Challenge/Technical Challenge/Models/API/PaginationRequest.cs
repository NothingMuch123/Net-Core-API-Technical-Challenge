using System.ComponentModel.DataAnnotations;

namespace Technical_Challenge.Models.API
{
    public class PaginationRequest
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(1, int.MaxValue)]
        public int Count { get; set; } = 20;
    }

    public class PaginationResponse
    {
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
    }
}
