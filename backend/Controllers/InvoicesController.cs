﻿using InvoiceApp.Data;
using InvoiceApp.DTOs.Invoice;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoicesController(AppDbContext context, IInvoiceRepository invoiceRepository)
        {
            _context = context;
            _invoiceRepository = invoiceRepository;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetInvoicesDTO>>> GetInvoices()
        {
            var invoices = await _invoiceRepository.GetInvoices();

            var mappedInvoices = invoices.Select(invoice =>
            new GetInvoicesDTO
            {
                ClientName = invoice.Client.Name,
                DueDate = invoice.DueDate,
                InvoiceId = invoice.InvoiceId,
                Status = invoice.Status,
                Total = invoice.Total
            }
            ).ToList();

            return mappedInvoices;

        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            if (_context.Invoices == null)
            {
                return Problem("Entity set 'AppDbContext.Invoices'  is null.");
            }
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            if (_context.Invoices == null)
            {
                return NotFound();
            }
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return (_context.Invoices?.Any(e => e.InvoiceId == id)).GetValueOrDefault();
        }
    }
}