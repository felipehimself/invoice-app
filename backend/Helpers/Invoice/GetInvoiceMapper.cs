﻿using InvoiceApp.DTOs.Client;
using InvoiceApp.DTOs.Invoice;
using InvoiceApp.Models;

namespace InvoiceApp.Helpers
{
    public class GetInvoiceMapper
    {
        public static ResponseInvoiceDTO MapInvoiceResponse(Invoice invoice)
        {
            var client = new ResponseClientInvoiceDTO
            {
                ClientId = invoice.Client.ClientId,
                City = invoice.Client.City,
                Country = invoice.Client.Country,
                Email = invoice.Client.Email,
                Name = invoice.Client.Name,
                PostalCode = invoice.Client.PostalCode,
                Street = invoice.Client.Street,
            };

            var invoiceItems = invoice.InvoiceItems.Select(item => new ResponseInvoiceItemDTO
            {
                InvoiceItemId = item.InvoiceItemId,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                Total = item.Total,
            }).ToList();

            return new ResponseInvoiceDTO
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
