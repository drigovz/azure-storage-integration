using AzureStorage.Domain.Entities;
using AzureStorage.Domain.Entities.Enums;
using Bogus;

namespace AzureStorage.Domain.Test.Builders
{
    public class CustomerBuilder
    {
        private static Faker faker = new Faker("en");

        private string FirstName = faker.Name.FirstName();
        private string LastName = faker.Name.LastName();
        private string Email = faker.Internet.Email();
        private string Identity = "30700696067";

        private static string imageUrl = faker.Image.LoremPixelUrl();
        private static byte[] file = faker.Random.Bytes(10);
        private static string fileName = faker.Random.String();

        private CustomerDocument document = new CustomerDocument(DocumentType.ProofAddress, imageUrl, file, fileName);

        public static CustomerBuilder New()
        {
            return new CustomerBuilder();
        }

        public CustomerBuilder CustomerWithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public CustomerBuilder CustomerWithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public CustomerBuilder CustomerWithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CustomerBuilder CustomerWithIdentity(string identity)
        {
            Identity = identity;
            return this;
        }

        public Customer Build()
        {
            return new Customer(FirstName, LastName, Email, Identity, document);
        }
    }
}
