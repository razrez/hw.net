using System;
using Logic.Models;

namespace DnD.UI.Models
{
    public class Fight
    {
        public Guid FightId { get; set; }
        public MyFighter Player { get; set; }
        public Monster Monster{ get; set; }
        public bool? PlayerWon { get; set; }
    }
}