using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class Administrators
    {
        [Key]
        public int administratorID { get; set; }
        public string administrator_name { get; set; } = string.Empty;
    }
}
