using System.ComponentModel.DataAnnotations;

namespace ASPMVC.Models
{
    public class AdditionClass
    {
        [Required]
        [MaxLength(100)]
        public string Prenom { get; set; }
        [Required]
        public int Chiffre1 { get; set; }
        [Required]
        public int Chiffre2 { get; set; }
        [Required]
        public int? Chiffre3 { get; set; }
    }
}
