using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class FileManagement
    {
        [Key]
        public int fileID { get; set; }
        public string file_name { get; set; } = string.Empty;
    }
}
