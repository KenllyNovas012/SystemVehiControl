using System.ComponentModel.DataAnnotations;

namespace SystemVehiControl.Models
{
    public class Engine
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Engine name is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
