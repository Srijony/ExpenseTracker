using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public interface IExpense
    {
        IEnumerable<Expense> GetAll();

        Expense GetById(int id);
        Expense Create(Expense expense);
        Expense Update(Expense expense);
        Expense Delete(int id);


    }
}
