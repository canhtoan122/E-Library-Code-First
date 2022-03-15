using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class NotificationManagement
    {
        [Key]
        public int notificationID { get; set; }
        public string notification_name { get; set; } = string.Empty;
        public string notification_description { get; set; } = string.Empty;
    }
}
