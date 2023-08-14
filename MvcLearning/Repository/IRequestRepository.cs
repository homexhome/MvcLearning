using MvcStartApp.Models.Db;

namespace MvcStartApp.Repository
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
