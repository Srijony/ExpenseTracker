using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public interface IExpenseCategory
    {
        IEnumerable<ExpenseCategory> GetAll();

        ExpenseCategory GetById(int id);
        ExpenseCategory Create(ExpenseCategory expense);
        ExpenseCategory Update(ExpenseCategory expense);
        ExpenseCategory Delete(int id);
    }
}
