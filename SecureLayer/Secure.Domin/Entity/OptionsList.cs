namespace Secure.Domain.Entity
{
    public class OptionsList : BaseEntity
    {
        public int OptionId { get; set; }
        [StringLength(ConstantHelpers.optionNameLength, ErrorMessage = ConstantHelpers.optionNameErrorMessage)]
        public string OptionName { get; set; }
        public ResponseWsdl ResponseWsdls { get; set; }
    }
}