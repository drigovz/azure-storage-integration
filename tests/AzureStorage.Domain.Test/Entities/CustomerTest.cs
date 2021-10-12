using AzureStorage.Domain.Test.Builders;
using FluentAssertions;
using Xunit;

namespace AzureStorage.Domain.Test
{
    public class CustomerTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [Trait("Domain", "Customers")]
        public void Should_Not_Create_Customer_With_Invalid_FirstName(string invalidName)
        {
            var customer = CustomerBuilder.New().CustomerWithFirstName(invalidName).Build();

            customer.Valid.Should().BeFalse();
            customer.ValidationResult.Errors.Should().NotBeEmpty();
            customer.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
            customer.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("FirstName"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [Trait("Domain", "Customers")]
        public void Should_Not_Create_Customer_With_Invalid_LastName(string invalidName)
        {
            var customer = CustomerBuilder.New().CustomerWithLastName(invalidName).Build();

            customer.Valid.Should().BeFalse();
            customer.ValidationResult.Errors.Should().NotBeEmpty();
            customer.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
            customer.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("LastName"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("exemple")]
        [InlineData("exemple@")]
        [InlineData("@exemple")]
        [Trait("Domain", "Customers")]
        public void Should_Not_Create_Customer_With_Invalid_Email(string invalidEmail)
        {
            var customer = CustomerBuilder.New().CustomerWithEmail(invalidEmail).Build();

            customer.Valid.Should().BeFalse();
            customer.ValidationResult.Errors.Should().NotBeEmpty();
            customer.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
            customer.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Email"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("307")]
        [InlineData("30700")]
        [InlineData("3070069")]
        [InlineData("307006960")]
        [InlineData("3070069606")]
        [Trait("Domain", "Customers")]
        public void Should_Not_Create_Customer_With_Invalid_Identity(string invalidIdentity)
        {
            var customer = CustomerBuilder.New().CustomerWithIdentity(invalidIdentity).Build();

            customer.Valid.Should().BeFalse();
            customer.ValidationResult.Errors.Should().NotBeEmpty();
            customer.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
            customer.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Identity"));
        }
    }
}
