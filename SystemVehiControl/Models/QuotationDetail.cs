using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class QuotationDetail
    {
        public int QuotationDetailId { get; set; }

        [Required]
        public int QuotationId { get; set; }  // Foreign key to Quotation

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Discount { get; set; }

        // Relationship with Quotation
        public Quotation Quotation { get; set; }

        // Relationship with Article
        public Article Article { get; set; }
    }
}
