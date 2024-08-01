using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.Salutation;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Employees.EmergencyContacts;
using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using ApwPayroll_Domain.Entities.Employees.EmployeeDepartments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDesignations;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using ApwPayroll_Domain.Entities.Employees.EmployeeFamiles;
using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using ApwPayroll_Domain.Entities.ReferralDetails;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Domain.Entities.Employees
{
    public class Employee : BaseAuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public string? ESINumber { get; set; }
        public string? PfNumber { get; set; }
 
        public DateTime DateOfJoining { get; set; }
        public int InsuranceNumber { get; set; } 
        public Int64 MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? UserId { get; set; }
        public AspUser? AspUser { get; set; }
        public bool? IsBrokerExamPass { get; set; }
        public DateTime StartedSalary { get; set; }
        public SalutationEnum Salutation { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public bool IsLoginAccess { get; set; }
        public string? PanNumber { get; set; }
        public Int64? AadharNumber { get; set; }
        public Int64? RationCardNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? VoterId { get; set; }
        public string? LicenceNumber { get; set; }
        public string? UanNumber { get; set; }
        public List<EmployeeDesignation>? EmployeeDesignations { get; set; } = new List<EmployeeDesignation>();
        public List<EmployeeDepartment>? EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();

        public List<BankDetail> BankDetails { get; set; }
        public List<EmployeeDocument>? EmployeeDocuments { get; set; } = new List<EmployeeDocument>();

       public  EmployeePersonalDetail EmployeePersonalDetail { get; set; }
 
        public List<EmployeeFamily> EmployeeFamily { get; set; } = new List<EmployeeFamily>();
 
        public List<EmployeeExperience>? EmployeeExperience { get; set; } = new List<EmployeeExperience>();
        public List<EmployeeQualification> EmployeeQualification { get; set; } = new List<EmployeeQualification>();
        public List<ReferralDetail> ReferralDetail { get; set; } = new List<ReferralDetail>();
        public List<EmergencyContact>? EmergencyContact { get; set; } = new List<EmergencyContact>();
        public List<EmployeeAddress>? EmployeeAddresses { get; set; } = new List<EmployeeAddress>();
      
        // degisnation working
        public void AddDesignation(int designationId)
        {
            EmployeeDesignations.Add(new EmployeeDesignation(designationId, Id, true));
        }
        public void AddIfNotDesignationExists(List<int> designationsId)
        {
            foreach (var designation in designationsId)
            {
                if (EmployeeDesignations.All(pu => pu.DesignationId != designation))
                {
                    EmployeeDesignations.Add(new EmployeeDesignation(designation, Id, true));
                }
            }
            RemoveDesignationExists(designationsId);
        }
        private void RemoveDesignationExists(List<int> emplyeeDesginationsId)
        {
            foreach (var designation in EmployeeDesignations)
            {
                if (!emplyeeDesginationsId.Contains(designation.DesignationId))
                {
                    designation.IsActive = false;
                }
            }
        }

        // department  working 
        public void AddDepartment(int departmentId)
        {
            EmployeeDepartments.Add(new EmployeeDepartment(departmentId, Id, true));
        }
        public void AddIfNotDepartmentExists(List<int> departmentIds)
        {
            // Add or reactivate departments in the new list
            foreach (var departmentId in departmentIds)
            {
                var existingDepartment = EmployeeDepartments.FirstOrDefault(pu => pu.DepartmentId == departmentId && pu.EmployeeId == Id);
                if (existingDepartment == null)
                {
                    EmployeeDepartments.Add(new EmployeeDepartment(departmentId, Id, true));
                }
                else
                {
                    existingDepartment.IsActive = true;
                }
            }

            // Deactivate departments not in the new list
            foreach (var department in EmployeeDepartments)
            {
                if (!departmentIds.Contains(department.DepartmentId))
                {
                    department.IsActive = false;
                }
            }
        }
        // Document working
        public void AddDocument(int documentId, int typeId, string? Code)
        {
            EmployeeDocuments.Add(new EmployeeDocument(documentId, Id, true, typeId,Code));
        }

        public void AddIfDocumentNotExists(List<int> documentId, int typeId)
        {
            foreach (var document in documentId)
            {
                if (EmployeeDocuments.All(pu => pu.DocumentId != document))
                {
                    EmployeeDocuments.Add(new EmployeeDocument(document, Id, true, typeId,null));
                }
                RemoveDocumentExists(documentId);

            }
        }

        private void RemoveDocumentExists(List<int> documentId)
        {
            foreach (var document in EmployeeDocuments)
            {
                if (!documentId.Contains(document.DocumentId))
                {
                    document.IsActive = false;
                }
            }
        }




    }
}
