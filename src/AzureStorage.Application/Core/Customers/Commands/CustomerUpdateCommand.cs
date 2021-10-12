namespace AzureStorage.Application.Core.Customers.Commands
{
    public class CustomerUpdateCommand : CustomerCommand
    {
        public int Id { get; set; }

        public CustomerUpdateCommand(int id)
        {
            Id = id;
        }
    }
}
