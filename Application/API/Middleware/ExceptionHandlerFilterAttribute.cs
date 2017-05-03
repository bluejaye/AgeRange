using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            
            context.HttpContext.Response.StatusCode = 500;
            context.Result = new ObjectResult(exception.InnerException != null ? exception.InnerException.Message : exception.Message);
        }

        private string GetExceptionMessage(Exception exception, out string result)
        {
            result =  "";
            if (string.IsNullOrEmpty(result))
            {
                result = string.Empty;
            }
            if(exception.InnerException != null)
            {
                GetExceptionMessage(exception.InnerException, out result);
            }else
            {
                result += exception.Message;
            }
            return result;
        }
    }
}
