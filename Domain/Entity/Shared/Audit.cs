namespace Domain.Entity.Shared
{
    public class Audit:BaseEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
