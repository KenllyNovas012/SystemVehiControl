using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(13, ErrorMessage = "El número debe tener máximo 13 caracteres.")]
        public string IdentificationNumber { get; set; } // Cedula or RNC
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número debe tener máximo 12 caracteres.")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string DocumentType { get; set; }
    }
}
