using Microsoft.AspNetCore.Mvc;

namespace BuilderAPI;

[Route("api/[Controller]")]
public class CompontenteController 
    (IComponenteService componenteService, IMapperAuthenticator mapperAuthenticator)
    : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllComponentesAsync()
    {
        try
        {
            var componentes = await componenteService.ListComponentesAsync();
            var componenteResources = mapperAuthenticator
            .MapResourcesFromEntities<Componente, ComponenteResource>(componentes);
            return Ok(componenteResources);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
