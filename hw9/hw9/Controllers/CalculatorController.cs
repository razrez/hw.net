using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
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
        
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Calculate(Calculator calcul)
        {
            if (!ModelState.IsValid)
            {
                return View(calcul);
            }

            var tree = MyExpressionTree.ConvertToBinaryTree(calcul.Expr.Replace(" ",""));
            return Content(Expression.Lambda<Func<double>>(new MyBinaryVisitor().Visit(tree))
                .Compile()
                .Invoke()
                .ToString());
        }

        [HttpGet]
        public ActionResult CalculateU([FromQuery] string expr)
        {
            if (!ModelState.IsValid)
                RedirectToAction("Index");
            var tree = MyExpressionTree.ConvertToBinaryTree(expr);
            return Content(Expression.Lambda<Func<double>>(new MyBinaryVisitor().Visit(tree))
                .Compile()
                .Invoke()
                .ToString());
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