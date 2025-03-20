using BusinessModelOperation;
using BusinessModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace PurchaseOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService _vendorService)
        {
            this._vendorService = _vendorService;
        }

        [HttpPost]
        [Route("/AddVendor")]
        public IActionResult AddVendor(VendorDetails vendorDetails)
        {
            try
            {
                var result = _vendorService.AddVendor(vendorDetails);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("/GetVendorList")]
        public IActionResult GetVendorList()
        {
            try
            {
                var result = _vendorService.GetVendorList();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpDelete]
        [Route("/DeleteVendor")]
        public IActionResult GetVendorList(int VendorID)
        {
            try
            {
                var result = _vendorService.DeleteVendor(VendorID);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
