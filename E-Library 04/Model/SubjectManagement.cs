using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class SubjectManagement
    {
        [Key]
        public int subjectID { get; set; }
        public string subject_name { get; set; } = string.Empty;
        public string subject_description { get; set; } = string.Empty;
    }
}
