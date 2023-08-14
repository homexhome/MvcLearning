using Microsoft.AspNetCore.Mvc;
using MvcLearning.Models;
using MvcStartApp.Models;
using System.Diagnostics;

public class FeedbackController : Controller
{
    /// <summary>
    ///  Метод, возвращающий страницу с отзывами
    /// </summary>
    [HttpGet]
    public IActionResult Add() {
        return View();
    }

    /// <summary>
    /// Метод для Ajax-запросов
    /// </summary>
    [HttpPost]
    public IActionResult Add(Feedback feedback) {
        return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}