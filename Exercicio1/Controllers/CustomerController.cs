using Exercicio1.Domain.DTOs;
using Exercicio1.Domain.Entities;
using Exercicio1.Domain.Interfaces.ServiceInterfaces;
using Exercicio1.Domain.ViewModels;
using Exercicio1.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet("v1/customers")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var customerList = await _customerService.GetAllCustomersAsync();

                IList<CustomerDTO> customerDTOList = new List<CustomerDTO>();

                foreach (var customer in customerList)
                {             
                    IList<ContactDTO> contactDTOList = new List<ContactDTO>();
                    
                    foreach (var contact in customer.Contacts)
                    {
                        var contactDTO = new ContactDTO
                        {
                            Id = contact.Id,
                            Name = contact.Name,
                            PhoneNumber = contact.PhoneNumber,
                            RelationshipType = contact.RelationshipType
                        };

                        contactDTOList.Add(contactDTO);
                    }

                    var customerDTO = new CustomerDTO
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email,
                        Contacts = contactDTOList
                    };

                    customerDTOList.Add(customerDTO);          
                }

                return Ok(new ResultDTO<IList<CustomerDTO>>(customerDTOList));   
            }
            catch
            {
                return StatusCode(500, new ResultDTO<IList<CustomerDTO>>("05XE2 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/customers/{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            try
            {
                var customer = await _customerService.SearchCustomerAsync(id);

                if (customer == null)
                    return NotFound(new ResultDTO<CustomerDTO>("Conteúdo não encontrado"));
                else
                {
                    IList<ContactDTO> contactsDtoList = new List<ContactDTO>();

                    if (customer.Contacts.Count != 0)
                    {
                        foreach (var contact in customer.Contacts)
                        {
                            var contactDTO = new ContactDTO
                            {
                                Id = contact.Id,
                                Name = contact.Name,
                                PhoneNumber = contact.PhoneNumber,
                                RelationshipType = contact.RelationshipType
                            };

                            contactsDtoList.Add(contactDTO);
                        }
                    }

                    var customerDTO = new CustomerDTO
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email,
                        Contacts = contactsDtoList
                    };

                    return Ok(new ResultDTO<CustomerDTO>(customerDTO));
                }
            }
            catch
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("05XE3 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/customers")]
        public async Task<IActionResult> PostAsync([FromBody] EditorCustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultDTO<CustomerDTO>(ModelState.GetErrors()));

                var newCustomer = new Customer
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };

                var retorno = await _customerService.AddCustomerAsync(newCustomer);

                var customerDTO = new CustomerDTO
                {
                    Id = retorno.Id,
                    Name = retorno.Name,
                    PhoneNumber = retorno.PhoneNumber,
                    Email = retorno.Email
                };

                return Created($"v1/customers/{customerDTO.Id}", new ResultDTO<int>(customerDTO.Id));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("05XE9 - Não foi possível incluir o cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("05X10 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/customers/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCustomerViewModel model)
        {
            try
            {
                var customer = await _customerService.SearchCustomerAsync(id);

                if (customer == null)
                    return NotFound(new ResultDTO<CustomerDTO>("Conteúdo não encontrado"));

                customer.Name = model.Name;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Email = model.Email;

                await _customerService.EditCustomerAsync(customer);

                IList<ContactDTO> contactsDtoList = new List<ContactDTO>();

                if (customer.Contacts.Count != 0)
                {
                    foreach (var contact in customer.Contacts)
                    {
                        var contactDTO = new ContactDTO
                        {
                            Id = contact.Id,
                            Name = contact.Name,
                            PhoneNumber = contact.PhoneNumber,
                            RelationshipType = contact.RelationshipType
                        };

                        contactsDtoList.Add(contactDTO);
                    }
                }

                var customerDTO = new CustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    Contacts = contactsDtoList
                };

                return Ok(new ResultDTO<CustomerDTO>(customerDTO));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("05XF7 - Não foi possível atualizar o cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("05X11 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/customers/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var customerDeleted = await _customerService.RemoveCustomerAsync(id);

                if (customerDeleted == false)
                    return NotFound(new ResultDTO<CustomerDTO>("Conteúdo não encontrado, ou é necessário excluir primeiro os contatos vinculados"));
                else
                    return Ok(new ResultDTO<int>(id));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("05XF1 - Não foi possível deletar o cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("05X12 - Falha interna no servidor"));
            }
        }
    }
}