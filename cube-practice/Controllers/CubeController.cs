using cube_practice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cube_practice.Controllers;

[ApiController]
public class CubeController(ICubeService cubeService) : ControllerBase
{

   [HttpGet]
   [Route("coindesk")]
   public async Task<ActionResult> CoinDesk()
   {
      var coinDesk = await cubeService.GetCoinDesk();
      return Ok(coinDesk);
   }
}