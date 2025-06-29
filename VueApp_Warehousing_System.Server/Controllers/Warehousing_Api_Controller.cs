using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using VueApp_Warehousing_System.Server.Model;

namespace VueApp_Warehousing_System.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Warehousing_ApiController : ControllerBase
    {
        private static List<Good_Model> goods = new List<Good_Model>()
        {
            new() { id= 1, name= "筆記型電腦", sku= "NB123", quantity= 10, unit= "台", location= "A1" },
            new() { id = 2, name = "滑鼠", sku = "MS456", quantity = 50, unit = "個", location = "B3" },
            new() {id = 3, name = "螢幕", sku = "MN789", quantity = 20, unit = "台", location = "C2"}
        };

        [HttpGet("GetGoods")]
        public IActionResult GetGoods()
        {
            return Ok(goods);
        }

        [HttpPost("InsertGood")]
        public IActionResult InsertGood([FromBody] Good_Model New_Good)
        {
           New_Good.id = goods.Count > 0 ? goods.Max(g => g.id) + 1 : 1;
           goods.Add(New_Good);

            return Ok();
        }

        //編輯更新

        [HttpPut("UpdateGood")]
        public IActionResult UpdateGood([FromBody] Good_Model updatedGood)
        {
            var good_index = goods.FindIndex (g => g.id == updatedGood.id);
            if (good_index == -1)
                return NotFound();
            
            goods[good_index] = updatedGood;
            return Ok();
        }

        //刪除

        [HttpDelete("DeleteGood")]
        public IActionResult DeleteGood([FromBody] Good_Model deletedGood)
        {
            var good_index = goods.FindIndex(g => g.id == deletedGood.id);
            if (good_index == -1)
                return NotFound();

            goods.RemoveAt(good_index); // Use RemoveAt instead of Remove to remove by index

            return Ok();
        }
    }
}
