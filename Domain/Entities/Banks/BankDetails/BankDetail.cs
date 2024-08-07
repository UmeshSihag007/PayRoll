using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayroll_Domain.Entities.Employees;

namespace ApwPayroll_Domain.Entities.Banks.BankDetails
{
    public class BankDetail : BaseAuditEntity
    {
        public int? BankId { get; set; }
        public Bank? Bank { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public long BanAccountId { get; set; }
        public bool IsBankAccountVerified { get; set; }
        public string IFCCode { get; set; }
        public string? AccountName { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public string? AccountBranch { get; set; }
    }
}
