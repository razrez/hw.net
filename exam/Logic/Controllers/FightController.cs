using System;
using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dnd.BLL.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class FightController
    {
        //приходит из UI
        public record FightInput(Character Player, Character Monster);
        private record FightResult(string Log);
        
        [HttpPost]
        public IActionResult Fight(FightInput input)
        {
            var (player, monster) = input;
            return new JsonResult(new FightResult(FightsProvider.LogFighting(player, monster)));
        }
    }
}