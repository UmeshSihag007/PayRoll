namespace ApwPayroll_Application.Interfaces.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(string userId);
        bool ValidateToken(string token);
    }
}
