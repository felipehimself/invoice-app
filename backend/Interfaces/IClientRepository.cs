using InvoiceApp.Models;

namespace InvoiceApp.Interfaces
{
    public interface IClientRepository
    {
        Task<Client?>? GetClient(int id);
        Task<IEnumerable<Client>> GetClients();
        Task<Client> PostClient(Client client);
        Task PutClient(Client client);
        Task DeleteClient(Client client);
    }
}
