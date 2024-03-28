using GoContacts.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoContacts.Controllers.API
{
    public class ContactsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IEnumerable<Contact> DeleteMultiple(List<int> ids)
        {
            IEnumerable<Contact> contacts = new List<Contact>();
            foreach (int id in ids)
            {
                Contact dbContact = _context.Contacts.SingleOrDefault(c => c.Id == id);
                if (dbContact == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {

                    IEnumerable<ContactGroupTag> dbContactGroupTags = _context.ContactGroupTags.Where(c => c.ContactId == dbContact.Id);
                    _context.ContactGroupTags.RemoveRange(dbContactGroupTags);
                    _context.Contacts.Remove(dbContact);
                    contacts.Append(dbContact);
                }
            }
            _context.SaveChanges();
            return contacts;
        }
    }
}
