using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    [DataContract]
    public class PurchaseOrder
    {
        [DataMember]
        public int OrderNumber { get; set; }  

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public int VendorID { get; set; }  

        [DataMember]
        public string OrderNotes { get; set; }  

        [DataMember]
        public Decimal OrderValue { get; set; }

        [DataMember]
        public int OrderStatus { get; set; }
    }

}
