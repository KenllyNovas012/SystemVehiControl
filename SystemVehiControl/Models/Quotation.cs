using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Quotation
    {
        public int QuotationId { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ReceiptType { get; set; }

        public string ReceiptSeries { get; set; }

        [Required]
        public string ReceiptNumber { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public string Status { get; set; }

        public ICollection<QuotationDetail> Details { get; set; }
        public User User { get; set; }
        public Person Person { get; set; }
    }
}
