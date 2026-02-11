

using System.ComponentModel.DataAnnotations;

namespace Archi.Library.Models
{
    public class TacosModel : BaseModel
    {
        // Id is inherited from BaseModel

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters long")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string Name { get; set; } = string.Empty;
        
        public string Sauce { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3, ErrorMessage = "{0} must be at least {1} characters long")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]

        public string Meat { get; set; } = string.Empty;

        [Range(0.00, 100.00, ErrorMessage = "{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
    }
}