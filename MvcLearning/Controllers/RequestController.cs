using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Repository;
using MvcStartApp.Models.Db;

namespace MvcLearning.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _repo;

        public RequestController(IRequestRepository repo) {
            _repo = repo;
        }
        public async Task<IActionResult> Logs() {
            var requests = await _repo.GetRequests();
            return View(requests);
        }
    }
}
