using cube_practice.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cube_practice.Controllers;

[ApiController]
public class CubeController: ControllerBase
{
   private readonly ICubeProxy _cubeProxy;

   public CubeController(ICubeProxy cubeProxy)
   {
      _cubeProxy = cubeProxy;
   }

   [HttpGet]
   [Route("coindesk")]
   public ActionResult CoinDesk()
   {
      _cubeProxy.GetCoinDesk();
      return Ok();
   }
}