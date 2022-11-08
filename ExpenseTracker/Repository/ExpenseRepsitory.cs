using ExpenseTracker.Data;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class ExpenseRepsitory : IExpense
    {
        private readonly DataClass dbContext;
        public ExpenseRepsitory(DataClass dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Expense> GetAll()
        {
            var list = (from expense in dbContext.Expenses.ToList()
                       from expenseCatagory in dbContext.ExpenseCategories.ToList()
                       where (expense.ExpenseCategoryId == expenseCatagory.ExpenseCategoryId) && 
                       ((expense.DateOfExpense.Date>=DateTime.Now.Date.AddDays(-1)) || expense.DateOfExpense.Date == DateTime.Now.Date)
                       select new Expense
                       {
                           ExpenseCategoryId = expense.ExpenseCategoryId,
                           DateOfExpense = expense.DateOfExpense,
                           ExpenseAmount = expense.ExpenseAmount,
                           ExpenseCategory = expenseCatagory,
                           ExpenseId= expense.ExpenseId,
                       }).ToList();


            return list;
        }

        public Expense GetById(int id)
        {
            return dbContext.Expenses.Where(x => x.ExpenseId == id).FirstOrDefault();
        }
        public Expense Create(Expense expense)
        {
            Expense exp = new Expense();
            exp.ExpenseAmount= expense.ExpenseAmount;
            exp.DateOfExpense= expense.DateOfExpense;
            exp.ExpenseCategoryId= expense.ExpenseCategoryId;
            dbContext.Expenses.Add(exp);
            dbContext.SaveChanges();
            return exp;
        
        }

        public Expense Delete(int id)
        {
            Expense expensedel = dbContext.Expenses.Find(id);
            if (expensedel !=null)
            {
                dbContext.Expenses.Remove(expensedel);
                dbContext.SaveChanges();
            }

            return expensedel;
        }
        public Expense Update(Expense expense)
        {
            Expense expenseUpdate = dbContext.Expenses.Find(expense.ExpenseId);

            if (expenseUpdate != null)
            {

                expenseUpdate.ExpenseAmount = expense.ExpenseAmount;
                expenseUpdate.DateOfExpense = expense.DateOfExpense;
                expenseUpdate.ExpenseCategoryId = expense.ExpenseCategoryId;
                dbContext.SaveChanges();
            }

            return expenseUpdate;
        }
    }

}
