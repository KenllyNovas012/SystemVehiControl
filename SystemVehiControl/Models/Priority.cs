using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Priority
    {
        public int PriorityId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]

        public string Level { get; set; } // e.g., "Low", "Medium", "High"
        [Required(ErrorMessage = "El campo es obligatorio.")]

        public string Description { get; set; }
    }
}
