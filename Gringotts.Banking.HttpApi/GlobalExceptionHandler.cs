using Gringotts.Banking.Shared.Abstractions;
using Microsoft.AspNetCore.Diagnostics;

namespace Gringotts.Banking.HttpApi
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception, "Exception occurred: {Message}", exception.Message);

            var result = Result.Failure(GetErrorFromException(exception));

            await httpContext.Response
                .WriteAsJsonAsync(result, cancellationToken);

            return true;
        }

        private static Error GetErrorFromException(Exception exception) =>
            exception switch
            {
                ErrorException errorException => errorException.Error,
                _ => new Error(999, "UnspecifiedError", exception.Message)
            };
    }
}