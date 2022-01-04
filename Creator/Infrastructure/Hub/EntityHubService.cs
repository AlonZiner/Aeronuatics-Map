using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Hub
{
    public class EntityHubService : IEntityHubService
    {
        private readonly IConfiguration _configuration;

        public EntityHubService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Notify(Entity entity)
        {
            try
            {
                using var httpClient = new HttpClient();

                var json = JsonSerializer.Serialize(entity);
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                var url = _configuration.GetSection("HubUrl").Value;
                var response = await httpClient.PostAsync(url, requestContent);
                var responseJson = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // TODO: logger
            }
            catch (Exception)
            {
                // TODO: logger
            }
        }
    }
}
