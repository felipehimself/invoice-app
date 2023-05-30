using InvoiceApp.DTOs;
using InvoiceApp.Models;

namespace InvoiceApp.Helpers
{
    public class ClientMapper
    {
        public static ClientResponseDTO MapClientResponse(Client client)
        {

            return new ClientResponseDTO
            {
                ClientId = client.ClientId,
                City = client.City,
                Street = client.Street,
                Country = client.Country,
                Email = client.Email,
                Name = client.Name,
                PostalCode = client.PostalCode,

            };
        }
    }
}
