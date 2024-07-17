using ApwPayroll_Domain.Entities.Documents;

namespace ApwPayroll_Domain.Entities.Banks.Branches.BranchDocuments
{
    public class BranchDocument
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public bool IsActive { get; set; }
    }
}
