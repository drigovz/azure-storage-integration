using FluentValidation;

namespace AzureStorage.Domain.Validations
{
    public static class ValidationsCollection
    {
        public static IRuleBuilderOptions<T, string> FirstName<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.NotNull().NotEmpty().WithMessage("FirstName is required!");

        public static IRuleBuilderOptions<T, string> LastName<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.NotNull().NotEmpty().WithMessage("LastName is required!");

        public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.NotNull().NotEmpty().EmailAddress();

        public static IRuleBuilderOptions<T, string> Identity<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.NotNull()
                       .WithMessage("Please enter Identity document")
                       .Must(IsValidCpf)
                       .WithMessage("Enter valid Identity document");

        private static bool IsValidCpf(string cpf)
        {
            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 },
                  multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string haveCpf, digit;
            int sum, rest;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            haveCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++) sum += int.Parse(haveCpf[i].ToString()) * multiplierOne[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            haveCpf += digit;
            sum = 0;

            for (int i = 0; i < 10; i++) sum += int.Parse(haveCpf[i].ToString()) * multiplierTwo[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();
            return cpf.EndsWith(digit);
        }
    }
}
