using System.ComponentModel.DataAnnotations;
using SystemVehiControl.Models;

namespace SystemVehiControl.Dto
{
    public class StockEntrydto
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

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
        public ICollection<StockEntryDetail> Details { get; set; }
    }
}
