using Microsoft.AspNetCore.Mvc;

namespace BuilderAPI;

[Route("api/[Controller]")]
public class ComputadoraController 
    (IComputadoraService computadoraService, IMapperAuthenticator mapperAuthenticator)
    : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var computadoras = await computadoraService.ListComputadoraAsync();
            var computadoraResources = mapperAuthenticator
            .MapResourcesFromEntities<Computadora, ComputadoraResource>(computadoras);
            return Ok(computadoras);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var computadora = await computadoraService.FindComputadoraAsync(id);
            var computadoraResource = mapperAuthenticator
                .MapResourceFromEntity<Computadora, ComputadoraResource>(computadora);
            return Ok(computadora);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveComputadoraResource saveComputadoraResource)
    {
        try
        {
            var nuevaComputadora = mapperAuthenticator
                .MapAndValidateEntity<SaveComputadoraResource, Computadora>(saveComputadoraResource);

            await computadoraService.AddComputadoraAsync(nuevaComputadora, saveComputadoraResource.ComponentesIds);

            var computadoraResource = mapperAuthenticator
                .MapResourceFromEntity<Computadora, ComputadoraResource>(nuevaComputadora);
            return Ok(computadoraResource);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
