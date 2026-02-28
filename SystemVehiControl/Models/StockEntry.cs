using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class StockEntry
    {
        public int StockEntryId { get; set; }

        [Required]
        public int SupplierId { get; set; }

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

        public ICollection<StockEntryDetail>? Details { get; set; }

        public User? User { get; set; }
        public Person? Supplier { get; set; }
    }
}
