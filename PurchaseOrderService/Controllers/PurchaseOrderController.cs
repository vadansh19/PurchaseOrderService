using BusinessModelOperation;
using BusinessModels.PurchaseOrderModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService ipurchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService ipurchaseOrderService)
        {
            this.ipurchaseOrderService = ipurchaseOrderService;
        }

        [HttpPost]
        [Route("/CreateNewOrder")]
        public IActionResult CreateNewOrder(CreateOrderBO createOrderBO)
        {
            try
            {
                var result = ipurchaseOrderService.CreateNewOrder(createOrderBO);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("/GetOrderList")]
        public IActionResult GetOrderList()
        {
            try
            {
                var result = ipurchaseOrderService.GetOrderList();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/GetSingleOrderDetails")]
        public IActionResult GetSingleOrderDetails(int OrderNo)
        {
            try
            {
                var result = ipurchaseOrderService.GetSingleOrderDetails(OrderNo);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
