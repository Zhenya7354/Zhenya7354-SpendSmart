using SpendSmart_Second_Web_application_.Data;
using SpendSmart_Second_Web_application_.Models;
using SpendSmart_Second_Web_application_.Services.Interface;

namespace SpendSmart_Second_Web_application_.Services
{
    public class HomeService : IDatabaseHome
    {
        private readonly SpendSmartDbContext _spendSmartDbContext;
        public HomeService(SpendSmartDbContext spendSmartDbContext)
        {
            _spendSmartDbContext = spendSmartDbContext;
        }
        public int Delete(int id)
        {
            var toDel = _spendSmartDbContext.Expenses.Find(id);
            _spendSmartDbContext.Expenses.Remove(toDel);
            if (_spendSmartDbContext.SaveChanges() > 0) { return id; }
            else { return -1; }
        }

        public Expense Get(int id)
        {
            return _spendSmartDbContext.Expenses.Find(id) ?? new Expense { Id = 0 };
        }

        public List<Expense> GetAll()
        {
            return _spendSmartDbContext.Expenses.ToList();
        }

        public int Save(Expense expense)
        {
            _spendSmartDbContext.Expenses.Add(expense);
            if(_spendSmartDbContext.SaveChanges() > 0) { return expense.Id; }
            else return -1;
        }
        public int Update(Expense expense)
        {
            _spendSmartDbContext.Expenses.Update(expense);
            if (_spendSmartDbContext.SaveChanges() > 0) { return expense.Id; }
            else return -1;
        }

        public Expense FindExp(int id)
        {
            return _spendSmartDbContext.Expenses.Find(id);
        }
    }
}
