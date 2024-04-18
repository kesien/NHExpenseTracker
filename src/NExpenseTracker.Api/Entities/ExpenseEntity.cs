using NExpenseTracker.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpenseTracker.Api.Entities
{
    public class ExpenseEntity
    {
        public Guid Id { get; set; }
        public ExpenseType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ExpenseCategory MyProperty { get; set; }
    }
}
