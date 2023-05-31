﻿namespace InvoiceApp.DTOs.Invoice
{
    public class GetInvoicesDTO
    {
        public int InvoiceId { get; set; }
        public DateTime DueDate { get; set; }
        public string ClientName { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }

    }
}