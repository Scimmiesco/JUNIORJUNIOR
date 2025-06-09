using System.ComponentModel.DataAnnotations;

namespace JJ.APPLICATION.DTOs
{
   public class CreateUpdateProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Url]
        public string? ImageUrl { get; set; }
    }
}