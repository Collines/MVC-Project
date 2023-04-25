namespace MVC_Project.Interfaces
{
    //Generic Repository Interface, all models that will have CRUD operations will implement it
    public interface IRepository<T>
    {
        public List<T>? GetAll();
        public T? GetById(int id);
        public void Insert(T t);
        public void Update(int id, T t);
        public void Delete(int id);
        public bool isExist(int id);
    }
}
