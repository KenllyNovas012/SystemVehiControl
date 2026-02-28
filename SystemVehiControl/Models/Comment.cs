namespace SystemVehiControl.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ServiceCaseId { get; set; }
        public ServiceCase ServiceCase { get; set; } // Relación con el caso

        public int UserId { get; set; }
        public User User { get; set; } // Relación con el usuario que comenta

        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
