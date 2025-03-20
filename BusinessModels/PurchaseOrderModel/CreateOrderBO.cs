using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.PurchaseOrderModel
{
    public  class CreateOrderBO
    {
        public PurchaseOrder PurchaseOrder { get; set; }
        public List<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
