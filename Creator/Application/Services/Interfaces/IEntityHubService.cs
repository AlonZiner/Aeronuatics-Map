using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IEntityHubService
    {
        Task Notify(Entity entity);
    }
}
