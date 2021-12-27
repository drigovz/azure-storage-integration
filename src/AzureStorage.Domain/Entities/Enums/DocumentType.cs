using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureStorage.Domain.Entities.Enums
{
    public enum DocumentType
    {
        [Display(Name = "ProofAddress")]
        [Description("ProofAddress")]
        ProofAddress,

        [Display(Name = "ProofIncome")]
        [Description("ProofIncome")]
        ProofIncome,

        [Display(Name = "ProofPayment")]
        [Description("ProofPayment")]
        ProofPayment,
    }
}
