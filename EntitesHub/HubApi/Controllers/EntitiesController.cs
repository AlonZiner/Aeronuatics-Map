using HubApi.Hubs;
using HubApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HubApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntitiesController : ControllerBase
    {
        
        private readonly ILogger<EntitiesController> _logger;
        private readonly EntitesHub _entitesHub;

        public EntitiesController(ILogger<EntitiesController> logger,
            EntitesHub entitesHub)
        {
            _logger = logger;
            _entitesHub = entitesHub;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Entity entity)
        {
            await _entitesHub.SendMessage(entity);

            return Ok();
        }
    }
}