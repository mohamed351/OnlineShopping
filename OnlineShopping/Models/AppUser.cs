namespace OnlineShopping.Models
{
    public class AppUser
    {
        public int ID { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserOrderType UserOrderType { get; set; }
        public bool IsDeactivate { get; set; }
    }
}
