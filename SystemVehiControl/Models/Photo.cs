using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string Description { get; set; } // Optional
        public DateTime TakenAt { get; set; }
        // Clave foránea para ExteriorInspection
        public int? ExteriorInspectionId { get; set; }
        public int? InteriorInspectionId { get; set; }
        public ExteriorInspection ExteriorInspection { get; set; }
        public InteriorInspection InteriorInspection { get; set; }
        

    }
}
