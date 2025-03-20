using BusinessModels;
using BusinessModels.PurchaseOrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public interface IPurchaseOrderService
    {
        int CreateNewOrder(CreateOrderBO createOrderBO);
        List<PurchaseOrder> GetOrderList();
        CreateOrderBO GetSingleOrderDetails(int OrderNo);
    }
}
