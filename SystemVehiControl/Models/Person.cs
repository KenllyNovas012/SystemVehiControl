using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        public string PersonType { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The person's name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<StockEntry> StockEntries { get; set; }
        public ICollection<Quotation> Quotations { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
