using InvoiceApp.DTOs.Client;
using InvoiceApp.DTOs.Invoice;
using InvoiceApp.Models;

namespace InvoiceApp.Helpers
{
    public class GetInvoiceMapper
    {
        public static GetInvoiceDTO MapInvoiceResponse(Invoice invoice)
        {
            var client = new ClientInvoiceDTO
            {
                ClientId = invoice.Client.ClientId,
                City = invoice.Client.City,
                Country = invoice.Client.Country,
                Email = invoice.Client.Email,
                Name = invoice.Client.Email,
                PostalCode = invoice.Client.PostalCode,
                Street = invoice.Client.Street,
            };

            var invoiceItems = invoice.InvoiceItems.Select(item => new GetInvoiceItemDTO
            {
                InvoiceItemId = item.InvoiceItemId,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                Total = item.Total,
            }).ToList();

            return new GetInvoiceDTO
            {

                Client = client,
                Description = invoice.Description,
                DueDate = invoice.DueDate.ToString("yyyy-MM-dd"),
                InvoiceId = invoice.InvoiceId,
                InvoiceItems = invoiceItems,
                IssueDate = invoice.IssueDate.ToString("yyy-MM-dd"),
                Status = invoice.Status,
                Total = invoice.Total,
            };
        }
    }
}
