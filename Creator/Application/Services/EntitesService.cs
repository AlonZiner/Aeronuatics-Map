using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class EntitesService : IEntitesService
    {
        private readonly IEntityHubService entityHubService;

        public EntitesService(IEntityHubService entityHubService)
        {
            this.entityHubService = entityHubService;
        }

        public async Task Create(Entity entity)
        {
            // manipulating/saving data...

            await entityHubService.Notify(entity);
        }
    }
}
