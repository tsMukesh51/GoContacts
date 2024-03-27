using GoContacts.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GoContacts.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Contact> contacts = _context.Contacts.Where(c => c.ApplicationUserId == userId);
            return View(contacts);
        }
        public ActionResult Create() 
        {
            Contact contact = new Contact();
            return View("ContactForm", contact);
        }
        public ActionResult Edit(int param)
        {
            //contact.ApplicationUserId = User.Identity.GetUserId();
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == param);
            if(contact == null)
            {
                return HttpNotFound();
            }
            contact.ApplicationUserId = "zxghop";
            return View("ContactForm", contact);
        }
        public ActionResult Save(Contact contact) 
        {
            contact.ApplicationUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return View("ContactForm", contact);
            }
            if (contact.Id == 0)
            {
                _context.Contacts.Add(contact);
            }
            else
            {
                Contact dbContact = _context.Contacts.SingleOrDefault(c => c.Id ==  contact.Id);
                if (dbContact == null)
                {
                    return HttpNotFound();
                }
                dbContact.Name = contact.Name;
                dbContact.Email = contact.Email;
                dbContact.Phone = contact.Phone;
                dbContact.Address = contact.Address;
                dbContact.Birthday = contact.Birthday;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Contacts");
        }
        public ActionResult Delete(int param)
        {
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == param);
            if (contact == null)
            {
                return HttpNotFound();
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}