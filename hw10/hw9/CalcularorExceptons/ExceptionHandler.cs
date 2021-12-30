using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace hw9.CalcularorExceptons
{
    public class ExceptionHandler:
        IExceptionHandler,IExceptionHandler<Exception>,
        IExceptionHandler<InvalidOperationException>,IExceptionHandler<KeyNotFoundException>,
        IExceptionHandler<NullReferenceException>
    {
        private ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }
        public void HandleException<T>(T exception) where T : Exception
        {
            Handle((dynamic) exception);
        }
        
        protected virtual void OnFallback(Exception exception)
        {
            _logger.LogError($"An error came out of nowhere: {exception}");
        }

        public void Handle(InvalidOperationException exception)
        {
            _logger.LogError($"Invalid operation: {exception}");
        }

        public void Handle(NullReferenceException exception)
        {
            _logger.LogError($"Invalid operation: {exception}");
        }

        public void Handle(KeyNotFoundException exception)
        {
            _logger.LogError($"Key not found: {exception}");
        }

        public void Handle(DivideByZeroException exception)
        {
            _logger.LogError($"Divide by zero: {exception}");
        }
        
        public void Handle(Exception exception)
        {
            OnFallback(exception);
        }
    }
}