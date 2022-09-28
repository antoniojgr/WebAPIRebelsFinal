using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIRebels.Application.Interfaces;
using WebAPIRebels.Application.Rebel;

namespace WebAPIRebels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RebeldesController : ControllerBase
    {
        private readonly IRebelService rebelService;

        public RebeldesController(IRebelService rebelService)
        {
            this.rebelService = rebelService;
        }

        [HttpPost]
        public async Task<ActionResult<RebelResponse>> Post([FromBody] RebelRequest rebelde)
        {
            //Comprobamos si el rebelde existe en la BD.
            if (await rebelService.ExistRebel(rebelde.RebelName, rebelde.PlanetName))
            {
                return BadRequest($"Ya existe un rebelde con el nombre {rebelde.RebelName} en el planeta {rebelde.PlanetName}");
            }

            //En caso de no existir, lo insertamos en la BD y creamos la cadena de texto que debe devolver cuando el registro va bien
            return Ok(await rebelService.CreateRebelRegister(rebelde.RebelName, rebelde.PlanetName));
        }
    }
}
