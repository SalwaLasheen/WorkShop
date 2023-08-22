using Domain.Entity.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class SqlResponseEntity : Audit
    {
        [StringLength(20, ErrorMessage = " Maxmium Length of Dial value cannot exceed 20 Numbers. ")]
        public string Dial { get; set; }
        [StringLength(70, ErrorMessage = " Method Name Length value cannot exceed 70 characters. ")]
        public string MethodName { get; set; }
        [Column("ResponseLog")]
        public string ResponseLogXml { get; set; }
    }
}
