using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETPCApp.Application.DTOs;
using NETPCApp.Application.Interfaces;

namespace NETPCApp.Server.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Get all contacts
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAllContactsAsync();
            return Ok(contacts);
        }

        /// <summary>
        /// Get contact
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
                return NotFound(new { Message = "Contact not found" });

            return Ok(contact);
        }

        /// <summary>
        /// Add contact
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactDTO contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactService.AddContactAsync(contactDto);
            return CreatedAtAction(nameof(GetById), new { id = contactDto.Id }, contactDto);
        }

        /// <summary>
        /// Update contact
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactDTO contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactService.UpdateContactAsync(id, contactDto);
            return NoContent();
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }
    }
}
