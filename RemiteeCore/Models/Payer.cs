using System;
using System.Collections.Generic;

namespace RemiteeCore.Models
{
    public partial class Payer
    {
        public Payer()
        {
            PayerBranch = new HashSet<PayerBranch>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<PayerBranch> PayerBranch { get; set; }
    }

    public class PayerRequest {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class PayerPutRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
