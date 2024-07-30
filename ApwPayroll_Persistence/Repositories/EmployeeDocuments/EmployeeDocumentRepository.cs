using ApwPayroll_Application.Common.Exceptions;
using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Application.Interfaces.Repositories.EmployeeDocuments;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocuments;
using ApwPayroll_Persistence.Data;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Repositories.EmployeeDocuments
{
    public class EmployeeDocumentRepository : IEmployeeDocumentRepository
    {
        private readonly string _bucketName = "certificate-dev-data";
        private readonly ApplicationDataContext _applicationDataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ImageTestingUrl = "https://localhost:7255/Images";
        private readonly CancellationToken cancellationToken;

        public EmployeeDocumentRepository(IWebHostEnvironment webHostEnvironment, ApplicationDataContext applicationDataContext)
        {

            _webHostEnvironment = webHostEnvironment;
            _applicationDataContext = applicationDataContext;
        }

        public async Task<EmployeeDocument> GetEmployeeDocument(int employeeId, int documentId)
        {
            var data= await _applicationDataContext.EmployeeDocuments.Where(x=>x.EmployeeId==employeeId &&x.DocumentId==documentId).FirstOrDefaultAsync();
            if(data!= null)
            {
                return data;
            }
            return data;
        }
    }
}
