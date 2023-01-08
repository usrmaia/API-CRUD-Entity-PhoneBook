using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Context;
using MyApp.Entities;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("contact")]
    public class ContactController : ControllerBase
    {
        private readonly PhoneBookContext _context;
        
        public ContactController(PhoneBookContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {   
            _context.Add(contact);
            _context.SaveChanges();
            //return Ok(contact);
            return CreatedAtAction(nameof(GetContact), new {Id = contact.Id}, contact);
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var contact = _context.Contacts;

            if (contact == null) return NotFound();
            return Ok(contact);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetContactsByName(string name)
        {
            var contacts = _context.Contacts.Where(values => values.Name.Contains(name));
            return Ok(contacts);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var getContact = _context.Contacts.Find(id);

            if (getContact == null) return NotFound();

            getContact.Name = contact.Name;
            getContact.PhoneNumber = contact.PhoneNumber;
            getContact.Active = contact.Active;

            _context.Contacts.Update(getContact);
            _context.SaveChanges();

            return Ok(getContact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var getContact = _context.Contacts.Find(id);

            if (getContact == null) return NotFound();

            _context.Contacts.Remove(getContact);
            _context.SaveChanges();

            return NoContent();

        }
    }
}