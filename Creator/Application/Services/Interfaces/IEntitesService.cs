using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IEntitesService
    {
        Task Create(Entity entity);
    }
}