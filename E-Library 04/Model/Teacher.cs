using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class Teacher
    {
        [Key]
        public int teacherID { get; set; }
        public string teacher_name { get; set; } = string.Empty;
    }
}
