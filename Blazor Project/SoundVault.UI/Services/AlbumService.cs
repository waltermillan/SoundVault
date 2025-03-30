using SoundVault.Model.Entities;
using SoundVault.UI.Interfaces;
using System.Text;
using System.Text.Json;

namespace SoundVault.UI.Services;

public class AlbumService : IAlbumService
{
    protected HttpClient _httpClient;

    public AlbumService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Delete(int id)
    {
        await _httpClient.DeleteAsync($"api/Albums/{id}");
    }

    public async Task<IEnumerable<Album>> GetAll()
    {
        var responseStream = await _httpClient.GetStreamAsync("api/Albums");
        return await JsonSerializer.DeserializeAsync<IEnumerable<Album>>(
            responseStream,
            options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Album>();
    }

    public async Task<Album> GetById(int id)
    {
        var responseStream = await _httpClient.GetStreamAsync($"api/Albums/{id}");
        return await JsonSerializer.DeserializeAsync<Album>(
            responseStream,
            options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new Album();
    }

    public async Task Save(Album album)
    {
        var albumJson = new StringContent(JsonSerializer.Serialize(album),
            Encoding.UTF8, "application/json");

        if (album.Id == 0)
            await _httpClient.PostAsync("api/Albums", albumJson);
        else 
            await _httpClient.PutAsync("api/Albums", albumJson);
    }

    public async Task Update(Album album)
    {
        var albumJson = new StringContent(JsonSerializer.Serialize(album),
            Encoding.UTF8, "application/json");

        var response = await _httpClient.PatchAsync("api/Albums", albumJson);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Error al actualizar la portada del álbum");
    }
}
