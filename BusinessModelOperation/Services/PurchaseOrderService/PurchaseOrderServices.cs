using BusinessModels;
using BusinessModels.PurchaseOrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModelOperation
{
    public class PurchaseOrderServices : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderServices(IPurchaseOrderRepository _purchaseOrderRepository)
        {
            this._purchaseOrderRepository = _purchaseOrderRepository;
        }

        public int CreateNewOrder(CreateOrderBO createOrderBO)
        {
            return _purchaseOrderRepository.CreateNewOrder(createOrderBO);
        }

        public List<PurchaseOrder> GetOrderList()
        {
            return _purchaseOrderRepository.GetOrderList();
        }
        public CreateOrderBO GetSingleOrderDetails(int OrderNo)
        {
            return _purchaseOrderRepository.GetSingleOrderDetails(OrderNo);
        }
    }
}
