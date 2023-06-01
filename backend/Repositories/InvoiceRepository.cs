using InvoiceApp.Data;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task DeleteInvoice(Invoice invoice)
        {
            _appDbContext.Invoices.Remove(invoice);
            await _appDbContext.SaveChangesAsync();

        }
        public async Task<Invoice> GetInvoice(int id)
        {
            return await _appDbContext.Invoices
                .Include(inv => inv.Client)
                .Include(inv => inv.InvoiceItems)
                .AsNoTracking()
                .SingleOrDefaultAsync(inv => inv.InvoiceId == id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _appDbContext.Invoices.Include(inv => inv.Client).Include(inv => inv.InvoiceItems).AsNoTracking().ToListAsync();
        }

        public async Task<Invoice> PostInvoice(Invoice invoice)
        {
            await _appDbContext.Invoices.AddAsync(invoice);
            await _appDbContext.SaveChangesAsync();
            var invoiceResponse = await GetInvoice(invoice.InvoiceId);
            return invoiceResponse;

        }

        public async Task PutInvoice(Invoice invoice)
        {
            _appDbContext.Invoices.Update(invoice);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
