using System.ComponentModel.DataAnnotations;

namespace E_Library_04.Model
{
    public class ExamAndTestManagement
    {
        [Key]
        public int exam_and_test_ID { get; set; }

        public string exam_and_test_name { get; set; } = string.Empty;
        public string exam_and_test_description { get; set; } = string.Empty;
        public string exam_bank { get; set; } = string.Empty;
        public string test_bank { get; set; } = string.Empty;
    }
}
