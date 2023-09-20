using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string  ContactType { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Booked { get; set; } = false;
        public string CustomId { get; set; }
        //[NotMapped]
        //public ICollection<string> Days { get; set; }
        //public string DaysString
        //{
        //    get { return string.Join(",", Days); }
        //    set { Days = value.Split(',').ToList(); }

        //}
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}
