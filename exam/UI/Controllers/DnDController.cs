using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;

namespace UI.Controllers;

public class DnDController : Controller
{
    private const string _dbUrl = "https://localhost:7162";
    private const string _urlFormat = "{0}/{1}/{2}";

    private readonly HttpClient _client;

    public DnDController()
    {
        _client = new HttpClient();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(new MyFighter());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] MyFighter fighter)
    {
        var monster =
            await _client.GetFromJsonAsync<Monster>(
                string.Format(_urlFormat, _dbUrl, "Monster", "GetMonster"));
        
        return Content($"{fighter.Name} DamagePerRound:{fighter.DamagePerRound} " +
                       $"vs {monster.Name} DamagePerRound:{monster.DamagePerRound}");
    }
}