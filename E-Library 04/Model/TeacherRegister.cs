namespace E_Library_04.Model
{
    public class TeacherRegister
    {
        public string teacher_username { get; set; } = string.Empty;
        public byte[] teacher_passwordHash { get; set; }
        public byte[] teacher_passwordSalt { get; set; }
    }
}
