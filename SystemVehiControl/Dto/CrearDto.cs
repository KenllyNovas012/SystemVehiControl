using System.ComponentModel.DataAnnotations;

namespace SystemVehiControl.Dto
{
    public class CrearDto
    {
        public int UserId { get; set; }  // Para edición, en creación puede ignorarse o ser 0

        [Required]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string DocumentType { get; set; }

        [Display(Name = "Número de Documento")]
        public string DocumentNumber { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; } // En edición puede ser opcional si no se desea cambiar

        [Display(Name = "Activo")]
        public bool IsActive { get; set; } = true;
    }
}
