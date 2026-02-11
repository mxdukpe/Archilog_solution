
using System.ComponentModel.DataAnnotations;

namespace Archi.Library.Models
{
    public abstract class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? CreationDate { get; set; }
    }
}
