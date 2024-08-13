using ApwPayroll_Domain.common.Enums.AccountType;

namespace ApwPayroll_Application.Features.Employees.EmployeeBankDetails.Commands.CreateEmployeeBankDetails
{
    public class CreateEmployeeBankDetailCommand
    {

        public int? Id { get; set; }
        public int EmployeeId { get; set; }
  //      public string? BankName { get; set; } 
        public int BankId { get; set; } 

        public long BanAccountId { get; set; }
        public bool? IsBankAccountVerified { get; set; }
        public string? IFCCode { get; set; }
        public string? AccountName { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public string? AccountBranch { get; set; }

    }

}

