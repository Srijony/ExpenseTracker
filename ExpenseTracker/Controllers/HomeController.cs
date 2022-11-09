using ExpenseTracker.Models;
using ExpenseTracker.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExpense Repository;
        private readonly IExpenseCategory ExpenseRepository;
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IExpense repository,IExpenseCategory expenseRepository)
        {
            Repository = repository;
            ExpenseRepository = expenseRepository;
        }

        public IActionResult Index()
        {
            
            var expenses = Repository.GetAll();
            return View(expenses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ExpenseCategories = new SelectList(ExpenseRepository.GetAll().ToDictionary(us => us.ExpenseCategoryId, us => us.ExpenseCategoryName), "Key", "Value");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense exp)
        {
            var AlreadyExists = Repository.GetAll().Where(x => x.ExpenseCategoryId == exp.ExpenseCategoryId).FirstOrDefault();
            if (AlreadyExists == null)
            {

                Repository.Create(exp);
                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.Message = string.Format(" This Category Is Already Exists !!! Firstly, Please CREATE New Category In EXPENSE CATEGORY Page ", exp);
                return View();
            }
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var exp= Repository.GetById(id);
            return View(exp);
        }
        [HttpPost]
        public IActionResult Edit(Expense exp)
        {

            Repository.Update(exp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            
            Repository.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}