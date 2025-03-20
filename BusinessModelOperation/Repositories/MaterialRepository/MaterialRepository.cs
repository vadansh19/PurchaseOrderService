using BusinessModels;
using CommonOperation;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public class MaterialRepository : IMaterialRepository
    {
        public int AddMaterial(MaterialDetails materialDetails)
        {
            List<SqlParameter> lstSqlParameters = new List<SqlParameter>();
            lstSqlParameters.Add(new SqlParameter("@MaterialID", materialDetails.MaterialID));
            lstSqlParameters.Add(new SqlParameter("@MaterialCode", materialDetails.MaterialCode));
            lstSqlParameters.Add(new SqlParameter("@ShortText", materialDetails.ShortText));
            lstSqlParameters.Add(new SqlParameter("@LongText", materialDetails.LongText));
            lstSqlParameters.Add(new SqlParameter("@ReorderLevel", materialDetails.ReorderLevel));  
            lstSqlParameters.Add(new SqlParameter("@MinOrderQuantity", materialDetails.MinOrderQuantity));  
            lstSqlParameters.Add(new SqlParameter("@Unit", materialDetails.Unit));
            lstSqlParameters.Add(new SqlParameter("@IsActive", materialDetails.IsActive));

            
            var result = DBOperation.GetInstance().ReturnDataTable("PuchaseOrder_Material_InsertUpdateMaterial", lstSqlParameters);

            return 1;  
        }


        public List<MaterialDetails> GetMaterialList()
        {
            List<MaterialDetails> materialList = new List<MaterialDetails>();

            var dt = DBOperation.GetInstance().ReturnDataTable("PurchaseOrder_GetMaterialMaster", null);

            if (dt != null && dt.Rows.Count > 0)
            {
                materialList = CollectionHelper.DataTableToArrayList<MaterialDetails>(dt);
            }

            return materialList;
        }



        public int DeleteMaterial(int materialID)
        {
            List<SqlParameter> lstSqlParameters = new List<SqlParameter>();
            lstSqlParameters.Add(new SqlParameter("@MaterialID", materialID));


            var result = DBOperation.GetInstance().ReturnDataTable("PuchaseOrder_Material_DeleteMaterial", lstSqlParameters);

            return 1;
        }

    }
}
