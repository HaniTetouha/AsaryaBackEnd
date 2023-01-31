namespace AsaryaBackEnd.Core.Models.Value
{
    public class Contact
    {
        public Contact(string homeNumber, string phoneNumber, string email)
        {
            HomeNumber = homeNumber;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string HomeNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
    }
}
