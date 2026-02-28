using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class StockEntryDetail
    {
        public int StockEntryDetailId { get; set; }

        [Required]
        public int StockEntryId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public StockEntry? StockEntry { get; set; }
        public Article Article { get; set; }
    }
}
