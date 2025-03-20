using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public interface IVendorRepository
    {
        int AddVendor(VendorDetails vendorDetails);
        List<VendorDetails> GetVendorList();

        int DeleteVendor(int VendorID);
    }
}
