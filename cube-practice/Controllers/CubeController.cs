using cube_practice.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cube_practice.Controllers;

[ApiController]
public class CubeController(ICubeProxy cubeProxy) : ControllerBase
{

   [HttpGet]
   [Route("coindesk")]
   public ActionResult CoinDesk()
   {
      cubeProxy.GetCoinDesk();
      return Ok();
   }
}