using ApwPayroll_Application.Contracts.Dtos;

namespace ApwPayrollWebApp.EnumHelpers
{
    public static class EnumHelper
    {
        public static IEnumerable<EnumHelperDto> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new EnumHelperDto { Id= Convert.ToInt32(e), Name = e.ToString() })
                .ToList();
        }
    }
    public   class EnumHelperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

}
