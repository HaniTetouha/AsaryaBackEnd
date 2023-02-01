using AsaryaBackEnd.Core.Models.Value;

namespace AsaryaBackEnd.Core.Models
{
    public class Customer
    {
        private Customer()
        {
        }
        public Customer(Person person)
        {
            Person = person;
        }
        public Customer(Person person, Address address) : this(person)
        {
            Address = address;
        }

        public Customer(Person person, Address address, Contact contact)
            : this(person, address)
        {
            Contact = contact;
        }

        public int Id { get; set; }
        public Person Person { get; private set; }
        public Address? Address { get; private set; }
        public Contact? Contact { get; private set; }
    }
}
