using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;

public class HolidatTypeRole : BaseAuditEntity
{
    public int HolidayId {  get; set; }

    public Holiday Holiday { get; set; }

    public GenderEnum Gender { get; set; }

    public int LocationId {  get; set; }
    public Location Location {  get; set; }

    public int BranchId {  get; set; }

    public Branch Branch { get; set; }

}
