using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CreatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntitiesController : ControllerBase
    {
        private readonly ILogger<EntitiesController> _logger;
        private readonly IEntitesService _entitesService;

        public EntitiesController(ILogger<EntitiesController> logger,
            IEntitesService entitesService)
        {
            _logger = logger;
            _entitesService = entitesService;
        }

        [HttpPost]
        public async Task<IActionResult> Get(Entity entity)
        {
            await _entitesService.Create(entity);

            return Created("", entity);
        }
    }
}