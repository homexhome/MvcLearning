using MvcStartApp.Models.Db;
using MvcStartApp.Repository;

namespace MvcLearning.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRequestRepository request) {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            var _request = new Request() {
                Url = $"New request to http://{context.Request.Host.Value + context.Request.Path}"
            };

            await request.AddRequest(_request);
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
