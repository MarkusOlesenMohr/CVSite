using CVSite.Domain.Common;

namespace CVSite.Domain.Master
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int AddressId { get; set; }
        public Address Address { get; set; } = new Address();
    }
}