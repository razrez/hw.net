using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using hw9.Models;
using hw9.MyExpressions.BinaryLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hw9.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _calculator;

        public CalculatorController(ILogger<CalculatorController> calculator)
        {
            _calculator = calculator;
        }
        
        public IActionResult Calculate([FromQuery] string input)
        {
            if (input == null) return Content("example: ../Calculate?input=(3+8)/2*3");
            var tree = MyExpressionTree.ConvertToBinaryTree(input);
            var result = Expression.Lambda<Func<double>>(new MyBinaryVisitor().Visit(tree)).Compile().Invoke();
            return Content(result.ToString());
        }
        
        public IActionResult Index()
        {
            return Content("example for filling: https://localhost:5001/Calculator/Calculate?input=(3+8)/2*3");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}