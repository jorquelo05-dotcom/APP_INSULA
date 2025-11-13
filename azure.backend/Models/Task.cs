namespace TerapiaApp.API.Models
{
    public class TherapyTask
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string PatientId { get; set; } = string.Empty;
        public string PsychologistId { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public string? PhotoUrl { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}