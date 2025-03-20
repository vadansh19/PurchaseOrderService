using BusinessModels;
using CommonOperation;
using CommonOperation.CommonHelper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public class VendorRepository : IVendorRepository
    {
        public int AddVendor(VendorDetails vendorDetails)
        {
            List<SqlParameter> lstSqlParameters = new List<SqlParameter>();
            lstSqlParameters.Add(new SqlParameter("@VendorID", vendorDetails.VendorID));
            lstSqlParameters.Add(new SqlParameter("@VendorCode", vendorDetails.VendorCode));  
            lstSqlParameters.Add(new SqlParameter("@VendorName", vendorDetails.VendorName));
            lstSqlParameters.Add(new SqlParameter("@AddressLine1", vendorDetails.AddressLine1));  
            lstSqlParameters.Add(new SqlParameter("@AddressLine2", vendorDetails.AddressLine2));  
            lstSqlParameters.Add(new SqlParameter("@ContactEmail", vendorDetails.ContactEmail));  
            lstSqlParameters.Add(new SqlParameter("@ContactNo", vendorDetails.ContactNo));  
            lstSqlParameters.Add(new SqlParameter("@ValidTillDate", vendorDetails.ValidTillDate));
            lstSqlParameters.Add(new SqlParameter("@IsActive", vendorDetails.IsActive));

            var result = DBOperation.GetInstance().ReturnDataTable("PuchaseOrder_Vendor_InsertUpdateVendor", lstSqlParameters);

            return 1;  
        }


        public List<VendorDetails> GetVendorList()
        {
            List<VendorDetails> vendorList = new List<VendorDetails>();

            // Execute the stored procedure to get vendor data
            var dt = DBOperation.GetInstance().ReturnDataTable("PurchaseOrder_GetVendorMaster", null);

            if (dt != null && dt.Rows.Count > 0)
            {
                vendorList = CollectionHelper.DataTableToArrayList<VendorDetails>(dt);
            }

            return vendorList;
        }

        public int DeleteVendor(int VendorID)
        {
            List<SqlParameter> lstSqlParameters = new List<SqlParameter>();
            lstSqlParameters.Add(new SqlParameter("@VendorID", VendorID));

            DBOperation.GetInstance().ExecureNonQuery("PuchaseOrder_Vendor_deleteVendor", lstSqlParameters , out FaultContract fault);

            return 1;
        }


    }
}
