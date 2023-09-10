using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class BookedEvents
    {
        [Key]
        public int Id { get; set; }
       
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
        public string GuestId { get; set; }
        [NotMapped]
        public ApiUser GuestData { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
