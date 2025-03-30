using SoundVault.Model;
using SoundVault.Model.Entities;
using SoundVault.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoundVault.UI.Services
{
    public class GenderService : IGenderService
    {
        private readonly HttpClient _httpClient;

        public GenderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Genders/{id}");
        }

        public async Task<IEnumerable<Gender>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Gender>>(
                  await _httpClient.GetStreamAsync("api/Genders"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Gender>();
        }

        public async Task<Gender> GetById(int id)
        {
            var jsonResult = await _httpClient.GetStreamAsync($"api/Genders/{id}");
            return await JsonSerializer.DeserializeAsync<Gender>(
                jsonResult,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new Gender();
        }

        public async Task Save(Gender genders)
        {
            var GenderJson = new StringContent(JsonSerializer.Serialize(genders),
                Encoding.UTF8, "application/json");

            if (genders.Id == 0)
                await _httpClient.PostAsync("api/Genders", GenderJson);
            else
                await _httpClient.PutAsync("api/Genders", GenderJson);
        }
    }
}
