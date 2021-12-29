using System;
using System.Linq.Expressions;
using hw9.Models;

namespace hw9.Services
{
    public class CacheCalculator:CalculatorDecorator
    {
        public string Input { get; set; }
        private CacheContext _context;
        public CacheCalculator(CacheContext ctx, ICalculator calculator) : base(calculator)
        {
            _context = ctx;
        }
        
        private Cache GetValue(string expr)
        {
            return _context.Cache.Find(expr);
        }
        
        private void Add(string expression, string value)
        {
            _context.Cache.Add(new Cache() {Expression = expression, Value = value});
            _context.SaveChanges();
        }

        public override double? Calculate(Expression node)
        {
            var val = GetValue(node.ToString());
            if (val != null)
            {
                return Convert.ToDouble(val.Value);
            }

            var newRecord = _calculator.Calculate(node);
            Add(node.ToString(),newRecord.ToString());
            return newRecord;
        }
    }
}