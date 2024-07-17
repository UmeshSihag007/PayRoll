using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Employees;

namespace ApwPayroll_Domain.Entities.Banks
{
    public class Bank : BaseAuditEntity
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool IsBankAccountVerified { get; set; }
        public int AccountNumber { get; set; }
        public string IFCCode { get; set; }
        public string AccountName { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}
