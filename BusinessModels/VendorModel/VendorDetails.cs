using System.Runtime.Serialization;

namespace BusinessModels
{
    [DataContract]
    public class VendorDetails
    {
        [DataMember]
        public int VendorID { get; set; }  

        [DataMember]
        public string VendorCode { get; set; }

        [DataMember]
        public string VendorName { get; set; }

        [DataMember]
        public string AddressLine1 { get; set; }  

        [DataMember]
        public string AddressLine2 { get; set; }  

        [DataMember]
        public string ContactEmail { get; set; }  

        [DataMember]
        public string ContactNo { get; set; }  

        [DataMember]
        public DateTime ValidTillDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }

}
