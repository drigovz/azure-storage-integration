using AzureStorage.Domain.Validations;

namespace AzureStorage.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Identity { get; private set; }
        public Document Documents { get; private set; }

        public Customer(int id, string firstName, string lastName, string email, string identity, Document documents)
        {
            Id = id;

            EntityValidation(this, new CustomerValidator());
        }

        public Customer(string firstName, string lastName, string email, string identity, Document documents)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Identity = identity;
            Documents = documents;

            EntityValidation(this, new CustomerValidator());
        }

        public Customer UpdateCustomer(string firstName, string lastName, string email, string identity, Document documents)
        {
            EntityValidation(this, new CustomerValidator());

            return this;
        }
    }
}
