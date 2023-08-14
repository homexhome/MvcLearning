using Microsoft.EntityFrameworkCore;
using MvcStartApp.Context;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context) {
            _context = context;
        }

        public async Task AddRequest(Request request) {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            // Добавление реквеста
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }


        public async Task<Request[]> GetRequests() {
            // Получим всех реквестов
            return await _context.Requests.ToArrayAsync();
        }
    }
}
