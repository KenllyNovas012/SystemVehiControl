using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{

    public class SaleDetail
    {
        public int SaleDetailId { get; set; }

        [Required]
        public int SaleId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Discount { get; set; }

        public Sale Sale { get; set; }
        public Article Article { get; set; }
    }
}
