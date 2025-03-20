using BusinessModels;
using BusinessModels.PurchaseOrderModel;
using CommonOperation;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        public int CreateNewOrder(CreateOrderBO createOrderBO)
        {
            
            List<SqlParameter> PurchaselstSqlParameters = new List<SqlParameter>();
            PurchaselstSqlParameters.Add(new SqlParameter("@OrderDate", createOrderBO.PurchaseOrder.OrderDate));
            PurchaselstSqlParameters.Add(new SqlParameter("@VendorID", createOrderBO.PurchaseOrder.VendorID));
            PurchaselstSqlParameters.Add(new SqlParameter("@OrderNotes", createOrderBO.PurchaseOrder.OrderNotes));
            PurchaselstSqlParameters.Add(new SqlParameter("@OrderValue", createOrderBO.PurchaseOrder.OrderValue));

            
            var result = DBOperation.GetInstance().ReturnDataTable("PuchaseOrderHeader_Insert", PurchaselstSqlParameters);

            
            int orderNumber = Convert.ToInt32(result.Rows[0]["OrderNumber"]);  



            foreach (var item in createOrderBO.PurchaseOrderDetails)
            {
                
                List<SqlParameter> PurchaseItemlstSqlParameters = new List<SqlParameter>();
                PurchaseItemlstSqlParameters.Add(new SqlParameter("@OrderID", orderNumber));  // Use OrderNumber
                PurchaseItemlstSqlParameters.Add(new SqlParameter("@MaterialID", item.MaterialID));
                PurchaseItemlstSqlParameters.Add(new SqlParameter("@ItemQuantity", item.ItemQuantity));
                PurchaseItemlstSqlParameters.Add(new SqlParameter("@ItemRate", item.ItemRate));
                PurchaseItemlstSqlParameters.Add(new SqlParameter("@ItemValue", item.ItemValue));
                PurchaseItemlstSqlParameters.Add(new SqlParameter("@ItemNotes", item.ItemNotes));
                PurchaseItemlstSqlParameters.Add(new SqlParameter("@ExpectedDate", item.ExpectedDate));

                
                var resultItem = DBOperation.GetInstance().ReturnDataTable("PuchaseOrderDetails_Insert", PurchaseItemlstSqlParameters);
            }

            
            return 1;
        }

        public List<PurchaseOrder> GetOrderList()
        {
            List<PurchaseOrder> purchaseOrdersList = new List<PurchaseOrder>();

            var dt = DBOperation.GetInstance().ReturnDataTable("PurchaseOrder_GetPurchaseOrderList", null);

            if (dt != null && dt.Rows.Count > 0)
            {
                purchaseOrdersList = CollectionHelper.DataTableToArrayList<PurchaseOrder>(dt);
            }

            return purchaseOrdersList;
        }

        public CreateOrderBO GetSingleOrderDetails(int OrderNo)
        {
            CreateOrderBO purchaseOrdersDetails = new CreateOrderBO();
            List<SqlParameter> PurchaseItemlstSqlParameters = new List<SqlParameter>();
            PurchaseItemlstSqlParameters.Add(new SqlParameter("@OrderID", OrderNo));

            DataSet ds = DBOperation.GetInstance().ReturnDataSet("PurchaseOrder_GetSingleOrderDetail", PurchaseItemlstSqlParameters);

            if (ds != null && ds.Tables.Count > 0)
            {
                purchaseOrdersDetails.PurchaseOrder = CollectionHelper.DataTableToBusinessObject<PurchaseOrder>(ds.Tables[0]);
                purchaseOrdersDetails.PurchaseOrderDetails = CollectionHelper.DataTableToArrayList<PurchaseOrderDetails>(ds.Tables[1]);

            }

            return purchaseOrdersDetails;
        }

    }
}
