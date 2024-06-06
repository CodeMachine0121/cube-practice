using Microsoft.AspNetCore.Mvc;

namespace cube_practice.Controllers;

[ApiController]
public class CubeController: ControllerBase
{
   [HttpGet]
   [Route("coindesk")]
   public ActionResult CoinDesk()
   {
      return Ok();
   }
}