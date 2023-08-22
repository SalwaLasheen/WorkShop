using Domain.Entity.Shared;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class ActionLogEntity : Audit
    {
        [StringLength(5, ErrorMessage = " Maxmium Length of Version  cannot exceed 5 Numbers. ")]
        public string AppVersion { get; set; }
        [StringLength(5, ErrorMessage = " Maxmium Length of Version  cannot exceed 5 Numbers. ")]
        public string OsVersion { get; set; }
        public bool IsAndroid { get; set; }
    }
}
