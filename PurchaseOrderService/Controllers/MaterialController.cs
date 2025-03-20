using BusinessModelOperation;
using BusinessModels;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService _materialService)
        {
            this._materialService = _materialService;
        }

        [HttpPost]
        [Route("/AddMaterial")]
        public IActionResult AddMaterial(MaterialDetails materialDetails)
        {
            try
            {
                var result = _materialService.AddMaterial(materialDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("/GetMaterialList")]
        public IActionResult GetMaterialList()
        {
            try
            {
                var result = _materialService.GetMaterialList();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpDelete]
        [Route("/DeleteMatrial")]
        public IActionResult DeleteMatrial( int materialID)
        {
            try
            {
                var result = _materialService.DeleteMaterial(materialID);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
