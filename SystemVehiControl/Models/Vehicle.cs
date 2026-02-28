using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número debe tener máximo 15 caracteres.")]
      
        public string ChassisNumber { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número debe tener máximo 15 caracteres.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número debe tener máximo 15 caracteres.")]
        public string LicensePlate { get; set; } // Placa
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Mileage { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número debe tener máximo 15 caracteres.")]
        public string FuelType { get; set; }
        public Brand Brand { get; set; }
        public int EngineId { get; set; }

        public Engine Engine { get; set; }

    }
}
