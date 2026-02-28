using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class NCF
    {
        public int Id { get; set; }
        public string NCFType { get; set; } = string.Empty;
        public int StartRange { get; set; }
        public int EndRange { get; set; }
        public int CurrentSequence { get; set; }
        public string VerificationCode { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
