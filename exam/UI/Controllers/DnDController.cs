using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;

namespace UI.Controllers;

public class DnDController : Controller
{
    private const string _dbUrl = "https://localhost:7162";
    private const string _format = "{0}/{1}/{2}";

    private readonly HttpClient _client;

    public DnDController()
    {
        _client = new HttpClient();
    }

    [BindProperty] public MyFighter Character { get; set; }
    public Monster Monster;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var monster =
            await _client.GetFromJsonAsync<Monster>(
                string.Format(_format, _dbUrl, "Monster", "GetMonster"));
        Monster = monster;
        
        return Content($"{monster.Name}{monster.DamagePerRound}");
    }
}