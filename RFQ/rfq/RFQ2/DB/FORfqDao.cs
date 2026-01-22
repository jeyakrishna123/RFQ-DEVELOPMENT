using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFQ2.DB
{
    class FORfqDao
    {
        public int Id { set; get; }
        public String MatlNbr { set; get; }
        public String RfqRefNbr { set; get; }
        public String VendorId { set; get; }
        public String ContryOfOrigin { set; get; }
        public String OrderQty { set; get; }
        public String VendorQuote { set; get; }
        public String UOM { set; get; }
        public String Currency { set; get; }
        public Double PriceScale1to3 { set; get; }
        public Double PriceScale4to9 { set; get; }

        public Double PriceScaleGT10 { set; get; }

        public String Remarks { set; get; }
        public String LeadTime { set; get; }
        public String ErrorStatus { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime ModifiedDate { set; get; }
    }
}
