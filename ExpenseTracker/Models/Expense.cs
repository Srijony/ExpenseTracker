using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        public DateTime DateOfExpense { get; set; }

        public int ExpenseAmount { get; set; }

        public int ExpenseCategoryId { get; set; }

        public ExpenseCategory ExpenseCategory { get; set; }

    }
}
