using ExpenseTracker.Data;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public class ExpenseCategoryRepository : IExpenseCategory
    {
        private readonly DataClass dbContext;
        public ExpenseCategoryRepository(DataClass dbContext)
        {
            this.dbContext = dbContext;
        }

        public ExpenseCategory Create(ExpenseCategory expense)
        {
            ExpenseCategory category = new ExpenseCategory();

            category.ExpenseCategoryId = expense.ExpenseCategoryId;
            category.ExpenseCategoryName = expense.ExpenseCategoryName;

            dbContext.ExpenseCategories.Add(category);
            dbContext.SaveChanges();

            return category;
        }

        public ExpenseCategory Delete(int id)
        {
            var ExpenseCategoryDel = dbContext.ExpenseCategories.Find(id);
            if (ExpenseCategoryDel != null)
            {
                dbContext.Remove(ExpenseCategoryDel);
                dbContext.SaveChanges();
            }
            return ExpenseCategoryDel;
        }

        public IEnumerable<ExpenseCategory> GetAll()
        {
            return dbContext.ExpenseCategories.ToList();
        }

        public ExpenseCategory GetById(int id)
        {
            return dbContext.ExpenseCategories.Find(id);
        }

        public ExpenseCategory Update(ExpenseCategory expense)
        {
            var ExpenseCategoryUpdate = dbContext.ExpenseCategories.Find(expense.ExpenseCategoryId);
            if (ExpenseCategoryUpdate != null)
            {
                ExpenseCategoryUpdate.ExpenseCategoryName = expense.ExpenseCategoryName;
                dbContext.SaveChanges();
            }
            return ExpenseCategoryUpdate;
        }
    }
}
