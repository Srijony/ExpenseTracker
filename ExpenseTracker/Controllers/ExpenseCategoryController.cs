using ExpenseTracker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly IExpenseCategory CategoryRepository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
