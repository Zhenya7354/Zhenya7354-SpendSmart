using SpendSmart_Second_Web_application_.Models;

namespace SpendSmart_Second_Web_application_.Services.Interface
{
    public interface IDatabaseHome
    {
         int Save(Expense expense);
         Expense Get(int id);
         List<Expense> GetAll();
        int Delete(int id);
         int Update(Expense expense);
        Expense FindExp(int id);
    }
}
