using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class ResourceManagement
    {
        [Key]
        public int resourceID { get; set; }
        public string resource_name { get; set; } = string.Empty;
        public string resource_description { get; set; } = string.Empty;
    }
}
