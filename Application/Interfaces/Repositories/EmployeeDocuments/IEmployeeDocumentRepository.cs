using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Interfaces.Repositories.EmployeeDocuments
{
    public interface IEmployeeDocumentRepository
    {
        Task<EmployeeDocument>GetEmployeeDocument(int employeeId, int documentId );
    }
}
