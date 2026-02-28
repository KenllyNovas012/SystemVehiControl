using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class InteriorInspection
    {
        public int Id { get; set; }
        public string UpholsteryOk { get; set; }
        public bool LighterOk { get; set; }
        public string ACFunctionality { get; set; } // "Cold", "Average", "Hot"
        public bool RadioOk { get; set; }
        public bool RadioSpeakersOk { get; set; }
        public string Doorwindows { get; set; }
        public string Doorlocks { get; set; }
        public string Carhorn { get; set; }
        public bool RearRightDoorOk { get; set; }
        public bool ExternalHornOk { get; set; }
        public int FloorMatCount { get; set; }
        public bool EmergencyKitOk { get; set; }

        public List<Photo> Photos { get; set; } = new();
    }
}
