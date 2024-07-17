using ApwPayroll_Domain.common.Interfaces;
using ApwPayroll_Domain.Entities.AspUsers;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Domain.common
{
    public class BaseAuditEntity : BaseEntity, IAuditableEntity
    {
        [ForeignKey("CreatedByUser")]
        public string? CreatedBy { get; set; }
        public AspUser? CreatedByUser { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey("UpdatedByUser")]
        public string? UpdatedBy { get; set; }
        public AspUser? UpdatedByUser { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
