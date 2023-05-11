using System;
using System.Collections.Generic;

namespace HCP.Packages.DL.Entities
{
    public partial class GtEacscc
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CreditPeriod { get; set; }
        public decimal CreditLimit { get; set; }
        public bool ValidateLimit { get; set; }
        public string CustomerOnHold { get; set; }
        public int HoldReason { get; set; }
        public bool IsLimitBreakupReqd { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
