using System.ComponentModel.DataAnnotations;

namespace SystemVehiControl.Dto
{
    public class VehicleReceptionDto
    {
        public int VehicleReceptionId { get; set; }
        // Datos generales de recepción
        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime ReceptionDate { get; set; }

        [Required]
        public TimeSpan ReceptionTime { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public string PersonalItems { get; set; }

        public string Observations { get; set; }

        public string VisitReason { get; set; }

        public string UpholsteryOk { get; set; }
        public bool LighterOk { get; set; }
        public string ACFunctionality { get; set; }
        public IFormFile? ExteriorPhoto1 { get; set; }
        public IFormFile? ExteriorPhoto2 { get; set; }
        public IFormFile? ExteriorPhoto3 { get; set; }
        public IFormFile? ExteriorPhoto4 { get; set; }
        public IFormFile? ExteriorPhoto5 { get; set; }
        public IFormFile? ExteriorVideo { get; set; }
        public IFormFile? InteriorPhoto4 { get; set; }
        public IFormFile? InteriorPhoto5 { get; set; }
        public IFormFile? InteriorPhoto6 { get; set; }
        public IFormFile? InteriorPhoto7 { get; set; }
        public IFormFile? InteriorPhoto8 { get; set; }
        public IFormFile? Interiorvideo { get; set; }
        public bool RadioOk { get; set; }
        public bool RadioSpeakersOk { get; set; }
        public string Doorwindows { get; set; }
        public string Doorlocks { get; set; }
        public string Carhorn { get; set; }
        public bool RearRightDoorOk { get; set; }
        public bool ExternalHornOk { get; set; }
        public int FloorMatCount { get; set; }
        public bool EmergencyKitOk { get; set; }

        public bool RadioAntennaOk { get; set; }
        public bool BeepersOk { get; set; }
        public bool SpareTirePresent { get; set; }
        public bool JackAndWrenchPresent { get; set; }
        public bool AlarmWorking { get; set; }
        public string MirrorCondition { get; set; }
        public string HoopGame { get; set; }
        public List<InspectionImageDto> InteriorImages { get; set; }  // 👈 Incluye ID y URL
        public List<InspectionImageDto> ExteriorImages { get; set; }
    }
}
