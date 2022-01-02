using System;
using System.Linq.Expressions;
using hw9.Models;

namespace hw9.Calculator
{
    public class CachingCalculator:Decorator
    {
        public string Input { get; set; }
        private CacheContext _context;

        public CachingCalculator(CacheContext ctx, ICalculator calculator) : base(calculator)
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

        public override string Calculate(Expression node)
        {
            var val = GetValue(node.ToString());
            if (val != null)
            {
                return val.Value;
            }

            var newRecord = _calculator.CalculateNew(node);
            Add(node.ToString(),newRecord);
            return newRecord;
        }
    }
}