using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class ServiceCase
    {
        public int Id { get; set; }

        public int VehicleReceptionId { get; set; }
        public VehicleReception VehicleReception { get; set; } // Asocia el caso con la recepción del vehículo


        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }

        public int UserId { get; set; }
        public User  GetUser { get; set; }

        public string Description { get; set; } // Descripción detallada del trabajo realizado

        public string Status { get; set; }
        public DateTime? CloseDate { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
