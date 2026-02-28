using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]

        [StringLength(30, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 30 characters.")]
        public string Name { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "El campo es obligatorio.")]

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
