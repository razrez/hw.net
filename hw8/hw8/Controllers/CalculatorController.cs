﻿using System.Diagnostics;
using System.Linq;
using hw8.Models;
using hw8.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hw8.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _calculator;
        private readonly ICalculateService _calculate;
        private static readonly string[] ExpectedOperation = 
        {
            "plus",
            "minus",
            "multiply",
            $"divide"
        };

        public CalculatorController(ILogger<CalculatorController> calculator, 
            ICalculateService calculate)
        {
            _calculator = calculator;
            _calculate = calculate;
        }

        public string Calculate(string val1, string operation, string val2)
        {
            var isVal1Int = int.TryParse(val1, out var num1);
            var isVal2Int = int.TryParse(val2, out var num2);

            if (!isVal1Int || !isVal2Int) //if there are no int args
            {
                return "Please, enter numbers";
            }
            if (num2 == 0 && operation == "divide")
            {
                return "divide by zero!";
            }
            
            return ExpectedOperation.Contains(operation) ? 
                _calculate.Calculate(num1, operation, num2) : "Unsupported operation!";
        }
        public IActionResult Index()
        {
            return Content("Content");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}