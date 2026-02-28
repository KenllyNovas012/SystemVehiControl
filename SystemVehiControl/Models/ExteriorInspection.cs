using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVehiControl.Models
{
    public class ExteriorInspection
    {
        public int Id { get; set; }
        public bool RadioAntennaOk { get; set; }
        public bool BeepersOk { get; set; }
        public bool SpareTirePresent { get; set; }
        public bool JackAndWrenchPresent { get; set; }
        public bool AlarmWorking { get; set; }
        public string MirrorCondition { get; set; }
        public string HoopGame { get; set; }

        public List<Photo> Photos { get; set; } = new();
    }
}
