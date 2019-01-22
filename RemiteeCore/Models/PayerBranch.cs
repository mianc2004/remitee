using System;
using System.Collections.Generic;

namespace RemiteeCore.Models
{
    public partial class PayerBranch
    {
        public int Id { get; set; }
        public int? PayerId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FormattedAddress { get; set; }

        public Payer Payer { get; set; }
    }


    public partial class PayerBranchRequest
    {
        public int? PayerId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FormattedAddress { get; set; }
    }

    public partial class PayerBranchPutRequest
    {
        public int Id { get; set; }
        public int? PayerId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FormattedAddress { get; set; }
    }
}
