using System.ComponentModel.DataAnnotations;

namespace RepasoMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}