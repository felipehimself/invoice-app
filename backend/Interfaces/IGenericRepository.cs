namespace InvoiceApp.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> FindById(int id);
        Task<IEnumerable<T>> FindAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
