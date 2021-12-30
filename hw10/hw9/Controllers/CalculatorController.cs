using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using hw9.Models;
using hw9.Calculator;
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
            var calculator = new CachingCalculator(_ctx, new Calculator.Calculator());
            try
            {
                var tree = ExpressionTree.ConvertToBinaryTree(input.Replace(" ", ""));
                var result = calculator.Calculate(tree);
                return Content(result);
            }
            catch (Exception ex)
            {
                return Content($"{ex.Message} :(");
            }
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