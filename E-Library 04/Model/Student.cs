using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class Student
    {
        [Key]
        public int studentID { get; set; }
        public string student_name { get; set; } = string.Empty;
    }
}
