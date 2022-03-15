using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class SystemManagement
    {
        [Key]
        public int systemID { get; set; }
        public string system_name { get; set; } = string.Empty;
    }
}
