using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SpendSmart_Second_Web_application_.Models;
using SpendSmart_Second_Web_application_.Services;
using System.Diagnostics;

namespace SpendSmart_Second_Web_application_.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;
        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult Expense()
        {
            var AllExpenses = _homeService.GetAll();
            var TotalExpences = AllExpenses.Sum(x=>x.Value);
            ViewBag.Exp = TotalExpences;
            return View(AllExpenses);
        }

        public IActionResult CreateEdit(int id)
        {
            if(id != null)
            {
                var ToEdit = _homeService.FindExp(id);
                return View(ToEdit);
            }
            return View();
        }

        public IActionResult SaveOrUpdate(Expense expense)
        {
            if (expense.Id == 0)
            {
                _homeService.Save(expense);
            }
            else
            {
                _homeService.Update(expense);
            }
            return RedirectToAction("Expense");
        }
        public IActionResult Delete(int id)
        {
            _homeService.Delete(id);
            return RedirectToAction("Expense");
        }
        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult FindBySearching(Search search)
        {
            if (search.Id == null) { return View(); }
            var FoundExp =_homeService.FindExp(search.Id);
            if (FoundExp is Expense) { return View(FoundExp); }
            if(FoundExp == null) { return NotFound($"Expense with id:{search.Id} Not Found. Please try again"); }
            return View();
        }
    }
}
