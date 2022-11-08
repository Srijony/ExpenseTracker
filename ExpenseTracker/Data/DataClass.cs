using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class DataClass : DbContext
    {
        public DataClass(DbContextOptions<DataClass> dbContextOptions) : base(dbContextOptions)
        {
        }
            public DbSet<Expense> Expenses { get; set; }

            public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        

    }
}
