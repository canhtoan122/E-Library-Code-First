using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class Admin
    {
        [Key]
        public int adminID { get; set; }
        public string admin_name { get; set; } = string.Empty;
    }
}
