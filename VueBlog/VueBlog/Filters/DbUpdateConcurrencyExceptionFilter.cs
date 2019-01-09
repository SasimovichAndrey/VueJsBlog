using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace VueBlog.Filters
{
    public class DbUpdateConcurrencyExceptionFilter : IExceptionFilter
    {
        public bool AllowMultiple => false;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if(actionExecutedContext.Exception is DbUpdateConcurrencyException)
            {
                _CreateResponseAccordingToException(actionExecutedContext);
            }

            return Task.FromResult<object>(null);
        }

        private static void _CreateResponseAccordingToException(HttpActionExecutedContext actionExecutedContext)
        {
            var responseStatusCode = HttpStatusCode.Conflict;
            var responseBody = JsonConvert.SerializeObject(actionExecutedContext.Exception);

            var response = new HttpResponseMessage(responseStatusCode);
            response.Content = new StringContent(responseBody);

            actionExecutedContext.Response = response;
        }
    }
}
