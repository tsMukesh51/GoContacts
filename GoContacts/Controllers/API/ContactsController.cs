using GoContacts.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        public IEnumerable<Contact> GetAll() 
        {
            return _context.Contacts.Where(c => c.ApplicationUserId == User.Identity.GetUserId());
        }
        [HttpPost]
        public IEnumerable<Contact> DeleteMultiple(List<int> ids)
        {
            IEnumerable<Contact> contacts = new List<Contact>();
            foreach (int id in ids)
            {
                Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == id);
                if (contact == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    _context.Contacts.Remove(contact);
                    contacts.Append(contact);
                }
            }
            _context.SaveChanges();
            return contacts;
        }
    }
}
