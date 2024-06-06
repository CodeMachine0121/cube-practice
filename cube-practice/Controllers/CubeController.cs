using cube_practice.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cube_practice.Controllers;

[ApiController]
public class CubeController(ICubeProxy cubeProxy) : ControllerBase
{

   [HttpGet]
   [Route("coindesk")]
   public async Task<ActionResult> CoinDesk()
   {
      var currenctPrice = await cubeProxy.GetCoinDesk();
      return Ok(currenctPrice);
   }
}