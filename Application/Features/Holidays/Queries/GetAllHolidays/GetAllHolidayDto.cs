using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Application.Contracts.Dtos;
using ApwPayroll_Domain.Entities.Holidays;

namespace ApwPayroll_Application.Features.Holidays.Queries.GetAllHolidays;

public class GetAllHolidayDto : IMapFrom<Holiday>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public bool IsNotifyToEmployee { get; set; }
    public bool IsResetToLeaveRequest { get; set; }
    public string Description { get; set; }
    public LookUpDto HolidayType { get; set; }
}
