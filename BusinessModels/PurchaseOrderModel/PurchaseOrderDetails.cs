using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.PurchaseOrderModel
{
    [DataContract]
    public class PurchaseOrderDetails
    {
        [DataMember]
        public int PurchaseOrderDetailsID { get; set; }  

        [DataMember]
        public int OrderID { get; set; }  

        [DataMember]
        public int MaterialID { get; set; }

        [DataMember]
        public int ItemQuantity { get; set; }  

        [DataMember]
        public int ItemRate { get; set; }  

        [DataMember]
        public int ItemValue { get; set; }  

        [DataMember]
        public string ItemNotes { get; set; }  

        [DataMember]
        public DateTime ExpectedDate { get; set; }
    }

}
