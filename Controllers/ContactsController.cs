using ContactsManagement.Models;
using ContactsManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactsManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsService _service;

        public ContactsController(ContactsService service)
        {
            _service = service;
        }

        // GET: api/contacts
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            return Ok(_service.GetAllContacts());
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
                return NotFound(new { Message = "Contact not found" });
            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public IActionResult AddContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.AddContact(contact))
                return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);

            return Conflict(new { Message = "Contact ID or email already exists" });
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.UpdateContact(id, contact))
                return NoContent();

            return NotFound(new { Message = "Contact not found" });
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            if (_service.DeleteContact(id))
                return NoContent();

            return NotFound(new { Message = "Contact not found" });
        }
    }
}
