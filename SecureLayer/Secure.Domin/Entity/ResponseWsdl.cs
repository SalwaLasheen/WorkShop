namespace Secure.Domain.Entity
{
    public class ResponseWsdl : BaseEntity
    {
        [StringLength(ConstantHelpers.DialLength, ErrorMessage = ConstantHelpers.DialErrorMessage)]
        public string Dial { get; set; }
        public int? BucketId { get; set; }
        [StringLength(ConstantHelpers.BucketNameLength, ErrorMessage = ConstantHelpers.BucketErrorMessage)]
        public string BucketName { get; set; }
        public bool? IsRnR { get; set; }
        [StringLength(ConstantHelpers.RnRTextLength, ErrorMessage = ConstantHelpers.RnRErrorMessage)]
        public string RnRText { get; set; }
        [StringLength(ConstantHelpers.ErrorCodeLength, ErrorMessage = ConstantHelpers.ErrorCode)]
        public string ErrorCode { get; set; }
        [StringLength(ConstantHelpers.ErrorMessageLength, ErrorMessage = ConstantHelpers.ErrorMessage)]
        public string ErrorMessage { get; set; }
        public int? Status { get; set; }
        public virtual ICollection<OptionsList> OptionsList { get; set; }
    }
}
