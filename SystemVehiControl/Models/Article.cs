using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string Code { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        public int Stock { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Category Category { get; set; }
        public ICollection<StockEntryDetail> StockEntryDetails { get; set; }
    }
}
