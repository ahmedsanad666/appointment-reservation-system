using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class UserAvailability
    {
        [Key]
        public int Id { get; set; }
        
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        [NotMapped]
        public ICollection<string> Days { get; set; }
        public string DaysString
        {
            get { return string.Join(",", Days); }
            set { Days = value.Split(',').ToList(); }
                
        }
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }

    }
}
