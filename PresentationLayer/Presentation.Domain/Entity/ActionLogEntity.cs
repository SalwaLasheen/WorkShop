namespace Presentation.Domain.Entity
{
    public class ActionLogEntity : BaseEntity
    {
        [StringLength(ConstantHelpers.DialLength, ErrorMessage = ConstantHelpers.DialErrorMessage)]
        public string Dial { get; set; }
        [StringLength(ConstantHelpers.MethodNameLength, ErrorMessage =ConstantHelpers.ErrorMethodName)]
        public string MethodName { get; set; }
        [StringLength(ConstantHelpers.ChannelNameLength, ErrorMessage = ConstantHelpers.ChannelNameErrorMessage)]
        public string ChannelName { get; set; }
        [StringLength(ConstantHelpers.AppVersionLength, ErrorMessage = ConstantHelpers.AppVersionErrorMessage)]
        public string AppVersion { get; set; }
        [StringLength(ConstantHelpers.OsVersionErrorLength, ErrorMessage =ConstantHelpers.OsVersionErrorMessage)]
        public string OsVersion { get; set; }
        public bool IsAndroid { get; set; }
    }
}
