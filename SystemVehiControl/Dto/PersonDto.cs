using System.ComponentModel.DataAnnotations;

namespace SystemVehiControl.Dto
{
    public class PersonDto
    {
        public int PersonId { get; set; }

        [Required]
        public string PersonType { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The person's name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
