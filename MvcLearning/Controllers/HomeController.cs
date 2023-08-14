using Microsoft.AspNetCore.Mvc;
using MvcLearning.Models;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using MvcStartApp.Repository;
using System.Diagnostics;

namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestRepository _requestRepository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo, IRequestRepository requestRepository) {
            _logger = logger;
            _repo = repo;
            _requestRepository = requestRepository;
        }

        public async Task<IActionResult> Index() {
            var newReq = new Request() {
                Date = DateTime.Now,
                Url = "111",
            };

            // Добавим в базу
            await _requestRepository.AddRequest(newReq);

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}