using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class HelpManagement
    {
        [Key]
        public int helpID { get; set; }
        public string help_name { get; set; } = string.Empty;
        public string help_description { get; set; } = string.Empty;
    }
}
