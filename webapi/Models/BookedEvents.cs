using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class BookedEvents
    {
        [Key]
        public int Id { get; set; }
        public  string HostId { get; set; }
        public string GuestId { get; set; }
        public ApiUser ApiUser { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
