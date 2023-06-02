using InvoiceApp.Data;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Repositories
{
    public class ClientRepository : IGenericRepository<Client>
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Remove(Client client)
        {
            _appDbContext.Remove(client);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Client?> FindById(int id)
        {
            return await _appDbContext.Clients.AsNoTracking().SingleOrDefaultAsync(client => client.ClientId == id);

        }

        public async Task<IEnumerable<Client>> FindAll()
        {
            return await _appDbContext.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client> Add(Client client)
        {
            await _appDbContext.Clients.AddAsync(client);
            await _appDbContext.SaveChangesAsync();
            return client;
        }

        public async Task Update(Client client)
        {
            _appDbContext.Clients.Update(client);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
