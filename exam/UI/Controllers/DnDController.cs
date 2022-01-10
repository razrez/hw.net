using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Models;

namespace UI.Controllers;

public class DnDController : Controller
{
    private const string _dbUrl = "https://localhost:7162";
    private const string _logicUrl = "https://localhost:7185";
    private const string _urlFormat = "{0}/{1}/{2}";

    private readonly HttpClient _client;

    public DnDController()
    {
        _client = new HttpClient();
    }
    
    private record FightStartingModel(Character Player, Character Monster);
    private record FightResult(string Log);
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //return View(new MyFighter());
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Character player)
    {
        var monster =
            await _client.GetFromJsonAsync<Character>(
                string.Format(_urlFormat, _dbUrl, "Monster", "GetMonster"));
        //у меня сейчас готовы мой боец и монстр
        
        
        var e = await _client.PostAsync("https://localhost:7185/Fight",
            JsonContent.Create(new FightStartingModel(player, monster!)));
                
        var log = (await e.Content.ReadFromJsonAsync<FightResult>())!.Log;
        
        return Content(log);
    }
}