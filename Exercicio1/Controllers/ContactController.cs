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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        [HttpPost("v1/contacts")]
        public async Task<IActionResult> PostAsync([FromBody] CreateContactViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultDTO<ContactDTO>(ModelState.GetErrors()));

                var newContact = new Contact
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    RelationshipType = model.RelationshipType,
                    CustomerId = model.CustomerId
                };

                var retorno = await _contactService.AddContactAsync(newContact);

                if (retorno == false)
                    return StatusCode(500, new ResultDTO<ContactDTO>("07XE9 - Não foi possível incluir o contato, pois o cliente já possui um contato com o mesmo relacionamento ou telefone"));
                else
                {
                    var contactDTO = new ContactDTO
                    {
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        RelationshipType = model.RelationshipType
                    };

                    return Created($"v1/contacts/{contactDTO.Id}", new ResultDTO<int>(contactDTO.Id));
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultDTO<ContactDTO>("07XE7 - Não foi possível incluir o contato"));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<ContactDTO>("07X10 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/contacts/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateContactViewModel model)
        {
            try
            {
                var contact = await _contactService.SearchContactAsync(id);

                if (contact == null)
                    return NotFound(new ResultDTO<CustomerDTO>("Conteúdo não encontrado"));

                contact.Name = model.Name;
                contact.PhoneNumber = model.PhoneNumber;
                contact.RelationshipType = model.RelationshipType;

                await _contactService.EditContactAsync(contact);

                var contactDTO = new ContactDTO
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    PhoneNumber = contact.PhoneNumber,
                    RelationshipType = contact.RelationshipType
                };

                return Ok(new ResultDTO<ContactDTO>(contactDTO));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultDTO<ContactDTO>("07XF7 - Não foi possível atualizar o contato"));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<ContactDTO>("07X11 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/contacts/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var wasRemoved = await _contactService.RemoveContactAsync(id);

                if (wasRemoved == false)
                    return NotFound(new ResultDTO<CustomerDTO>("Conteúdo não encontrado"));
                else
                    return Ok(new ResultDTO<int>(id));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("07XF1 - Não foi possível deletar o contato"));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<CustomerDTO>("07X12 - Falha interna no servidor"));
            }
        }
    }
}