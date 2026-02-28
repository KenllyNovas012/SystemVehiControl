using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
