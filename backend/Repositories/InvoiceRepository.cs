using InvoiceApp.Data;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Repositories
{
    public class InvoiceRepository : IGenericRepository<Invoice>
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Remove(Invoice invoice)
        {
            _appDbContext.Invoices.Remove(invoice);
            await _appDbContext.SaveChangesAsync();

        }
        public async Task<Invoice?> FindById(int id)
        {
            return await _appDbContext.Invoices
                .Include(inv => inv.Client)
                .Include(inv => inv.InvoiceItems)
                .AsNoTracking()
                .SingleOrDefaultAsync(inv => inv.InvoiceId == id);
        }

        public async Task<IEnumerable<Invoice>> FindAll()
        {
            return await _appDbContext.Invoices.Include(inv => inv.Client).Include(inv => inv.InvoiceItems).AsNoTracking().ToListAsync();
        }

        public async Task<Invoice> Add(Invoice invoice)
        {
            await _appDbContext.Invoices.AddAsync(invoice);
            await _appDbContext.SaveChangesAsync();
            var invoiceResponse = await FindById(invoice.InvoiceId);
            return invoiceResponse!;

        }

        public async Task Update(Invoice invoice)
        {
            _appDbContext.Invoices.Update(invoice);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
