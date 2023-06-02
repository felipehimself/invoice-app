using InvoiceApp.DTOs;
using InvoiceApp.Helpers;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly IGenericRepository<Client> _clientRepository;

        public ClientsController(IGenericRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientResponseDTO>>> GetClients()
        {
            var clientes = await _clientRepository.FindAll();

            return clientes.Select(c => ClientMapper.MapClientResponse(c)).ToList();

        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseDTO>> GetClient(int id)
        {
            var client = await _clientRepository.FindById(id);

            if (client == null) return NotFound();

            var response = ClientMapper.MapClientResponse(client);

            return response;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientRequestDTO clientDto)
        {
            var client = await _clientRepository.FindById(id);

            if (client == null) return BadRequest();

            var clientToSave = new Client
            {
                ClientId = client.ClientId,
                City = clientDto.City,
                Country = clientDto.Country,
                Email = clientDto.Email,
                Name = clientDto.Name,
                PostalCode = clientDto.PostalCode,
                Street = clientDto.Street,
            };

            await _clientRepository.Update(clientToSave);

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<ClientResponseDTO>> PostClient(ClientRequestDTO clientDto)
        {
            var client = new Client
            {
                City = clientDto.City,
                Country = clientDto.Country,
                Email = clientDto.Email,
                Name = clientDto.Name,
                PostalCode = clientDto.PostalCode,
                Street = clientDto.Street,
            };

            await _clientRepository.Add(client);

            var res = ClientMapper.MapClientResponse(client);

            return CreatedAtAction("GetClient", new { id = client.ClientId }, res);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientRepository.FindById(id);

            if (client == null) return NotFound();

            await _clientRepository.Remove(client);

            return NoContent();
        }
    }
}
