using ApwPayroll_Application.Contracts.Dtos;

namespace ApwPayrollWebApp.EnumHelpers
{
    public static class EnumHelper
    {
        public static IEnumerable<LookUpDto> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new LookUpDto { Id= Convert.ToInt32(e), Name = e.ToString() })
                .ToList();
        }
    }

}
