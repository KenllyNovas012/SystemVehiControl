using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class VehicleReception
    {
        public int VehicleReceptionId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime ReceptionDate { get; set; }
        public TimeSpan ReceptionTime { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int InteriorInspectionId { get; set; }
        public InteriorInspection InteriorInspection { get; set; }

        public int ExteriorInspectionId { get; set; }
        public ExteriorInspection ExteriorInspection { get; set; }

        public string PersonalItems { get; set; }
        public string Observations { get; set; }

        public string VisitReason { get; set; }
    }
}
