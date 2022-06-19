using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NBook.Models
{
    public class CoverType
    {
        [Key]//annotations
        public int Id { get; set; }

        [Display(Name="Cover Type")]
        [Required]
        public string Name { get; set; }

       
    }
}
