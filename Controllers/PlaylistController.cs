using ApiWithMongo.Models;
using ApiWithMongo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithMongo.Controllers
{
  [Controller]
  [Route("api/[controller]")]
  public class PlaylistController : ControllerBase
  {
    private readonly MongoDBService _mongoDBService;

    public PlaylistController(MongoDBService mongoDBService)
    {
      _mongoDBService = mongoDBService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist)
    {
      await _mongoDBService.CreateAsync(playlist);
      return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }

    [HttpGet]
    public async Task<List<Playlist>> Get()
    {
      return await _mongoDBService.GetAsync();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
    {
      await _mongoDBService.AddToPlaylistAsync(id, movieId);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      await _mongoDBService.DeleteAsync(id);
      return NoContent();

    }


  }
}