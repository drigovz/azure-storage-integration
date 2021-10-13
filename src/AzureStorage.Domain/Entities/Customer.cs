using AzureStorage.Domain.Validations;
using System.Collections.Generic;
using System.Linq;

namespace AzureStorage.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Identity { get; private set; }
        public IList<CustomerDocument> Documents { get; set; }

        public Customer(int id, string firstName, string lastName, string email, string identity)
        {
            Id = id;

            EntityValidation(this, new CustomerValidator());
        }

        public Customer(string firstName, string lastName, string email, string identity)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Identity = identity;

            EntityValidation(this, new CustomerValidator());
        }

        public List<CustomerDocument> AddDocuments(CustomerDocument document)
        {
            Documents.Add(document);
            return Documents.ToList();
        }

        public Customer UpdateCustomer(string firstName, string lastName, string email, string identity)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Identity = identity;

            EntityValidation(this, new CustomerValidator());

            return this;
        }
    }
}
