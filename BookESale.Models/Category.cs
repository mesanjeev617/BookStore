
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//means inside BookEsale under Models folder...
namespace BookESale.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Order needs to be in between 1 and 100 ")]
        public int DisplayOrder { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now;

    }
}
