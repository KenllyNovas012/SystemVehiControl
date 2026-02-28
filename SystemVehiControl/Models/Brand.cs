using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]

        public string Name { get; set; }
    }
}
