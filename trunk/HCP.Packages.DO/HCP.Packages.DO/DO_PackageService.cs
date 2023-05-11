using System;
using System.Collections.Generic;
using System.Text;

namespace HCP.Packages.DO
{
    public class DO_PackageService
    {
        public int BusinessKey { get; set; }
        public int PackageId { get; set; }
        public int ServiceType { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal ServiceRate { get; set; }
        public bool ActiveStatus { get; set; }

        public string ServiceDesc { get; set; }

    }
}
