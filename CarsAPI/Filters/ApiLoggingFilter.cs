﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace CarsAPI.Filters
{
    public class ApiLoggingFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        // Executa antes da action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("###################################################");
            _logger.LogInformation($" {DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState ({context.ModelState.IsValid}");
            _logger.LogInformation("###################################################");
        }
        //Executa depois da action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("### Executando -> OnActionExecuting");
            _logger.LogInformation("###################################################");
            _logger.LogInformation($" {DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState ({context.ModelState.IsValid}");
            _logger.LogInformation("###################################################");
        }
    }
}
