using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    [DataContract]
    public class MaterialDetails
    {
        [DataMember]
        public int MaterialID { get; set; }

        [DataMember]
        public string MaterialCode { get; set; }

        [DataMember]
        public string ShortText { get; set; }

        [DataMember]
        public string LongText { get; set; }

        [DataMember]
        public int ReorderLevel { get; set; }  

        [DataMember]
        public int MinOrderQuantity { get; set; } 

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }

}
