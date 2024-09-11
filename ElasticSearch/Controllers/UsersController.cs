using ElasticSearch.Services;
using Microsoft.AspNetCore.Mvc;
using ElasticSearch.Models;
namespace ElasticSearch.Controllers;
[ApiController]
[Route("[controller]")]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly IElasticService<User> _elasticService;

    public UsersController(ILogger<UsersController> logger, IElasticService<User> elasticService)
    {
        _logger = logger;
        _elasticService = elasticService;
    }
    [HttpPost("create-index")]
    public async Task<IActionResult> CreateIndex(string indexName)
    {
        await _elasticService.CreateIndexIfNotExistsAsync(indexName);
        return Ok($"Index {indexName} created or already exists.");
    }
    [HttpPost("add-user")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        var result = await _elasticService.AddOrUpdate(user);

        return result ? Ok("User added or updated successfully") : StatusCode(500,"Error adding or updating user");
    }
    [HttpPost("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        var result = await _elasticService.AddOrUpdate(user);

        return result ? Ok("User added or updated successfully") : StatusCode(500, "Error adding or updating user");
    }
    [HttpPost("get-user/{key}")]
    public async Task<IActionResult> GetUser(string key)
    {
        var result = await _elasticService.Get(key);

        return result != null ? Ok(result) : StatusCode(500, "Error users");
    }
    [HttpPost("get-all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _elasticService.GetAll();

        return result != null ? Ok(result) : StatusCode(500, "Error users");
    }
    [HttpPost("delete-user/{key}")]
    public async Task<IActionResult> DeleteUser(string key)
    {
        var result = await _elasticService.Remove(key);

        return result ? Ok("User deleted success") : StatusCode(500, "Error deleting user");
    }
    [HttpPost("delete-all")]
    public async Task<IActionResult> DeleteAll()
    {
        var result = await _elasticService.RemoveAll();

        return result != null ? Ok("All users deleted success") : StatusCode(500, "Error deleting user");
    }
}
