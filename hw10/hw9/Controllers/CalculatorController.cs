using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using hw9.Models;
using hw9.MyExpressions.BinaryLogic;
using hw9.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hw9.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _calculator;
        private readonly CacheContext _ctx;
        public CalculatorController(ILogger<CalculatorController> calculator, CacheContext ctx)
        {
            _calculator = calculator;
            _ctx = ctx;
        }
        
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Calculate(string input)
        {
            /*if (!ModelState.IsValid)
            {
                return View(calcul);
            }*/

            var calculator = new CacheCalculator(_ctx, new Calculator());
            var tree = MyExpressionTree.ConvertToBinaryTree(input.Replace(" ", ""));
            return Content(calculator.Calculate(tree).ToString());
        }

        [HttpGet]
        public ActionResult CalculateU([FromQuery] string expr)
        {
            return RedirectToAction("Index"); 
        } 
        
        [HttpGet]
        public IActionResult Index()
        {
            return Content("example for filling: \nhttps://localhost:5001/calculator/calculateu?expr=1/2");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}