using hw8.Services;
using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class CalculatorController: Controller
    {
        [HttpGet("add")]
        public IActionResult Add([FromServices] ICalculator calculator, double arg1, double arg2)
        {
            return Content(calculator.Add(arg1, arg2).ToString());
        }
        
        [HttpGet("subtract")]
        public IActionResult Subtract([FromServices] ICalculator calculator, double arg1, double arg2)
        {
            return Content(calculator.Subtract(arg1, arg2).ToString());
        }
        
        [HttpGet("divide")]
        public IActionResult Divide([FromServices] ICalculator calculator, double arg1, double arg2)
        {
            return Content(calculator.Divide(arg1, arg2).ToString());
        }
        
        [HttpGet("multiply")]
        public IActionResult Multiply([FromServices] ICalculator calculator, double arg1, double arg2)
        {
            return Content(calculator.Multiply(arg1, arg2).ToString());
        }

    }
}