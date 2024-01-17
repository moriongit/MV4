using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cars.Models
{
    public class AutoAccessory
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(32),NotNull,MinLength(5)]
        public string Name { get; set; }
        [MaxLength(128), NotNull, MinLength(5)]
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
