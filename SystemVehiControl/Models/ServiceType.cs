using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]

        public string Name { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]

        public string Description { get; set; }
    }
}
