using System.ComponentModel.DataAnnotations;
namespace E_Library_04.Model
{
    public partial class FileData
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}
