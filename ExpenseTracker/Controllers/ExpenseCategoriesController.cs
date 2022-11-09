using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Controllers
{
    public class ExpenseCategoriesController : Controller
    {
        private readonly IExpenseCategory _expense;

        public ExpenseCategoriesController(IExpenseCategory expense)
        {
            _expense = expense;
        }

        public IActionResult Index()
        {
              return View(_expense.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Create(ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                var AlreadyExists = _expense.GetAll().Where(x => x.ExpenseCategoryName == expenseCategory.ExpenseCategoryName).FirstOrDefault();
                if (AlreadyExists == null)
                {
                    _expense.Create(expenseCategory);
                }
                else
                {

                    ViewBag.Message = string.Format(" This Category Is Already Exists !!! Please Enter New One ", expenseCategory);
                    return View();
                }
               
                return RedirectToAction("Index");
            }
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }

            var expenseCategory = _expense.GetById(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }
            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(int id, ExpenseCategory expenseCategory)
        {
            if (id != expenseCategory.ExpenseCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _expense.Update(expenseCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(expenseCategory);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var expenseCategory =  _expense.GetById(id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _expense.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseCategoryExists(int id)
        {
          return _expense.GetById(id).Equals(null);
        }
    }
}
