using InvoiceApp.DTOs.Invoice;
using InvoiceApp.Helpers;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private readonly IGenericRepository<Invoice> _invoiceRepository;

        public InvoicesController(IGenericRepository<Invoice> invoiceRepository)
        {

            _invoiceRepository = invoiceRepository;
        }

        // GET: api/invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseInvoicesDTO>>> GetInvoices()
        {
            var invoices = await _invoiceRepository.FindAll();

            var mappedInvoices = invoices.Select(invoice =>
            new ResponseInvoicesDTO
            {
                ClientName = invoice.Client.Name,
                DueDate = invoice.DueDate.ToString("yyyy-MM-dd"),
                InvoiceId = invoice.InvoiceId,
                Status = invoice.Status,
                Total = invoice.Total
            }
            ).ToList();

            return mappedInvoices;

        }

        // GET: api/invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseInvoiceDTO>> GetInvoice(int id)
        {
            var invoice = await _invoiceRepository.FindById(id);

            if (invoice == null)
            {
                return NotFound();
            }
            var mappedInvoice = GetInvoiceMapper.MapInvoiceResponse(invoice);

            return mappedInvoice;
        }

        // PUT: api/invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, RequestInvoiceDTO invoiceDTO)
        {

            var invoice = await _invoiceRepository.FindById(id);

            if (invoice == null) return NotFound();

            var invoiceToUpdate = new Invoice
            {
                InvoiceId = id,
                ClientId = invoiceDTO.ClientId,
                IssueDate = invoice.IssueDate,
                Description = invoiceDTO.Description,
                DueInDays = invoiceDTO.DueInDays,
                Status = invoiceDTO.Status,
                InvoiceItems = invoiceDTO.Items.Select(item => new InvoiceItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                }).ToList(),
            };

            await _invoiceRepository.Update(invoiceToUpdate);

            return NoContent();
        }

        // POST: api/invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseInvoiceDTO>> PostInvoice(RequestInvoiceDTO invoiceDTO)
        {
            var invoice = new Invoice
            {
                ClientId = invoiceDTO.ClientId,
                IssueDate = invoiceDTO.IssueDate,
                Description = invoiceDTO.Description,
                DueInDays = invoiceDTO.DueInDays,
                Status = invoiceDTO.Status,
                InvoiceItems = invoiceDTO.Items.Select(item => new InvoiceItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                }).ToList(),
            };

            var invoiceSaved = await _invoiceRepository.Add(invoice);

            var invoiceMapped = GetInvoiceMapper.MapInvoiceResponse(invoiceSaved);

            return CreatedAtAction("GetInvoice", new { id = invoiceMapped.InvoiceId }, invoiceMapped);
        }

        // DELETE: api/invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _invoiceRepository.FindById(id);
            if (invoice == null)
            {
                return NotFound();
            }



            await _invoiceRepository.Remove(invoice);

            return NoContent();
        }
    }
}
