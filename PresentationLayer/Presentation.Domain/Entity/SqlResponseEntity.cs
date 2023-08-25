namespace Presentation.Domain.Entity
{
    public class SqlResponseEntity : BaseEntity
    {
        [StringLength(ConstantHelpers.DialLength, ErrorMessage =ConstantHelpers.DialErrorMessage)]
        public string Dial { get; set; }
        [StringLength(ConstantHelpers.MethodNameLength, ErrorMessage = ConstantHelpers.ErrorMethodName)]
        public string MethodName { get; set; }
        [StringLength(ConstantHelpers.ErrorCodeLength, ErrorMessage = ConstantHelpers.ErrorCode)]
        public string ErrorCode { get; set; }
        [StringLength(ConstantHelpers.ErrorMessageLength, ErrorMessage = ConstantHelpers.ErrorMessage)]
        public string ErrorMessage { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
