using BusinessModelOperation;
using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository _vendorRepository)
        {
            this._vendorRepository = _vendorRepository;
        }
        public int AddVendor(VendorDetails vendorDetails)
        {
            return _vendorRepository.AddVendor(vendorDetails);
        }

        public List<VendorDetails> GetVendorList()
        {
            return _vendorRepository.GetVendorList();
        }

        public int DeleteVendor(int VendorID)
        {
            return _vendorRepository.DeleteVendor(VendorID);
        }
    }
}
