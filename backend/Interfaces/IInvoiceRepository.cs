using InvoiceApp.Models;

namespace InvoiceApp.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<Invoice> GetInvoice(int id);
        Task<Invoice> PostInvoice(Invoice invoice);
        Task PutInvoice(Invoice invoice);
        Task DeleteInvoice(Invoice invoice);

    }
}
