using AsaryaBackEnd.Core.Models.Value;

namespace AsaryaBackEnd.Core.Models
{
    public class Supplier
    {
        public Supplier(Person person)
        {
            Person = person;
        }

        public Supplier(Person person, Address address) : this(person)
        {
            Address = address;
        }

        public Supplier(Person person, Address address, Contact contact)
            : this(person, address)
        {
            Contact = contact;
        }

        public long Id { get; set; }
        public Person Person { get; private set; }
        public Address? Address { get; private set; }
        public Contact? Contact { get; private set; }
    }
}
