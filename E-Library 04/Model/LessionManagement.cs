using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class LessionManagement
    {
        [Key]
        public int lessionID { get; set; }
        public string lession_name { get; set; } = string.Empty;
        public string lession_description { get; set; } = string.Empty;
    }
}
