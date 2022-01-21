using System.ComponentModel.DataAnnotations;

namespace ParksLookup.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        [Required]
        public string NatOrState { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        public int rating { get; set; }
    }
}