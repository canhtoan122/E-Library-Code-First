namespace E_Library_04.Model
{
    public class AdministratorsRegister
    {
        public string administrator_username { get; set; } = string.Empty;
        public byte[] administrator_passwordHash { get; set; }
        public byte[] administrator_passwordSalt { get; set; }
    }
}
