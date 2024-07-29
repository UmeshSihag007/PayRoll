using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees;

namespace ApwPayroll_Domain.Entities.Leaves.LeaveResponseStatues;

public class LeaveResponseStatus : BaseAuditEntity
{
    public int LeaveId { get; set; }
    public Leave Leave { get; set; }
    public int ResponseById { get; set; }
    public Employee Employee { get; set; }
    public string ResponseRemark { get; set; }

    // lead  status 
    public DateTime ResponseDate { get; set; }
    public int? ForwordId { get; set; }
    public Employee Forword { get; set; }
}
