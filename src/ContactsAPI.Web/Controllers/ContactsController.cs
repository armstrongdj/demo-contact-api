using ContactsAPI.Web.Infrastructure;
using ContactsAPI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsContext context;

        public ContactsController(ContactsContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await context.Contacts.SingleOrDefaultAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpGet("lastname/{lastName:minlength(1)}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactsByLastName(string lastName)
        {
            //todo: add pagination
            lastName = lastName.ToLower();
            return await context.Contacts.Where(c => c.LastName.ToLower() == lastName).ToListAsync();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<Contact>> GetContactByEmployeeId(string employeeId)
        {
            employeeId = employeeId.ToLower();
            var employee = await context.Contacts.SingleOrDefaultAsync(c => c.EmployeeId.ToLower() == employeeId);

            if(employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpGet("employee/{employeeId}/related")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetRelatedContacts(string employeeId)
        {
            employeeId = employeeId.ToLower();
            var employee = await context.Contacts.SingleOrDefaultAsync(c => c.EmployeeId.ToLower() == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return employee.RelatedContacts.Select(rc => rc.RelatedContact).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact([FromBody]Contact contact)
        {
            //prevent overposting
            //todo: consider move to AutoMapper or similar library
            var newContact = new Contact
            {
                LastName = contact.LastName,
                FirstName = contact.FirstName,
                EmployeeId = contact.EmployeeId,
                Email = contact.Email,
                CellPhone = contact.CellPhone,
                HomePhone = contact.HomePhone,
                OfficePhone = contact.OfficePhone,
                DateOfBirth = contact.DateOfBirth,
                DateOfHire = contact.DateOfHire,
                CurrentlyEmployed = contact.CurrentlyEmployed,
                ContactAddresses = contact.ContactAddresses.Select(ca => new ContactAddress { 
                    AddressType = ca.AddressType,
                    Address = new Address
                    {
                        Line1 = ca.Address.Line1,
                        Line2 = ca.Address.Line2,
                        City = ca.Address.City,
                        State = ca.Address.State,
                        ZipCode = ca.Address.ZipCode
                    }
                }).ToList(),
                RelatedContacts = contact.RelatedContacts.Select(cr => new ContactRelationship
                {
                    Relationship = cr.Relationship,
                    RelatedContact = new Contact
                    {
                        LastName = cr.RelatedContact.LastName,
                        FirstName = cr.RelatedContact.FirstName,
                        EmployeeId = null,
                        Email = cr.RelatedContact.Email,
                        CellPhone = cr.RelatedContact.CellPhone,
                        HomePhone = cr.RelatedContact.HomePhone,
                        OfficePhone = cr.RelatedContact.OfficePhone,
                        DateOfBirth = cr.RelatedContact.DateOfBirth,
                        DateOfHire = null,
                        CurrentlyEmployed = false,
                    }
                }).ToList()
            };

            context.Contacts.Add(newContact);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { id = newContact.Id }, newContact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact([FromBody]Contact contact)
        {
            var updateContact = await context.Contacts.SingleOrDefaultAsync(c => c.Id == contact.Id);

            if (updateContact == null)
            {
                return NotFound();
            }

            //todo: need to determine an update strategy for addresses and related contacts
            updateContact = contact;
            context.Contacts.Update(updateContact);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { id = updateContact.Id }, updateContact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var contact = await context.Contacts.SingleOrDefaultAsync(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
