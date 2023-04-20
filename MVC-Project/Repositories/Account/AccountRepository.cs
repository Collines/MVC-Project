using MVC_Project.Interfaces;
using MVC_Project.Models.Identity;

namespace MVC_Project.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        public AccountRepository(AppDBContext DB)
        {
            this.DB = DB;
        }

        public AppDBContext DB { get; }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Account>? GetAll()
        {
            return DB.Accounts.ToList();
        }

        public Account? GetById(int id)
        {
            return DB.Accounts.Find(id);
        }

        public void Insert(Account t)
        {
            DB.Accounts.Add(t);
            DB.SaveChanges();
        }

        public bool isExist(int id)
        {
            return DB.Accounts.Any(A=>A.Id== id);
        }

        public void Update(int id, Account t)
        {
            throw new NotImplementedException();
        }

    }
}
