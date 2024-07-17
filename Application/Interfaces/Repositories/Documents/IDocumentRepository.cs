using ApwPayroll_Domain.Entities.Documents;
using Microsoft.AspNetCore.Http;

namespace ApwPayroll_Application.Interfaces.Repositories.Documents
{
    public interface IDocumentRepository
    {
        Task<Document> CreateDocument(IFormFile file, string? Tittle = default, int? TypeId = default);
        Task<Document> updateDocument(int id, IFormFile file, string? Tittle = default, int? TypeId = default);
    }
}
