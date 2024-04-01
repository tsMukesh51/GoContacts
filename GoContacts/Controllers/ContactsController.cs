using GoContacts.Models;
using GoContacts.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
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
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Index(int? group)
        {
            string userId = User.Identity.GetUserId();
            if(_context.Users.SingleOrDefault(u => u.Id == userId).IsEnabled == true)
            {
                //IEnumerable<Contact>
                IQueryable<Contact> contacts = _context.Contacts.Include(c => c.ContactGroupTags).Where(c => c.ApplicationUserId == userId);
                IEnumerable<Contact> contactsInGroup;
                //IEnumerable<ContactGroupTag> contactGroups = _context.ContactGroupTags.ToList();
                if (group != null)
                {
                    contactsInGroup = contacts.Where(c => c.ContactGroupTags.Any(cg => cg.GroupTagId == group.Value));
                }
                else
                {
                    contactsInGroup = contacts;
                }
                //return View(contacts);

                IEnumerable<GroupTag> groupTags = _context.GroupTags.Where(c => c.ApplicationUserId == userId);

                ContactGroupTags contactGroupTags = new ContactGroupTags()
                {
                    Contacts = contactsInGroup,
                    GroupTags = groupTags
                };
                return View("ContactList", contactGroupTags);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create() 
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<GroupTag> dbGroupTag = _context.GroupTags.Where(c => c.ApplicationUserId == userId); 
            if (!dbGroupTag.Any())
            {
                dbGroupTag = new List<GroupTag>();
            }
            ContactGroupTagForm form = new ContactGroupTagForm()
            {
                Contact = new Contact(),
                GroupTags = dbGroupTag
            };
            return View("ContactForm", form);
        }
        public ActionResult Edit(int param)
        {
            //contact.ApplicationUserId = User.Identity.GetUserId();
            string userId = User.Identity.GetUserId();
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == param);
            if(contact == null)
            {
                return HttpNotFound();
            }
            contact.ApplicationUserId = "zxghop";
            ContactGroupTagForm form = new ContactGroupTagForm()
            {
                Contact = contact,
                GroupTags = _context.GroupTags.Where(c => c.ApplicationUserId == userId)
            };
            return View("ContactForm", form);
        }
        public ActionResult Save(ContactGroupTagForm contactGroupTagForm) 
        {
            string userId = User.Identity.GetUserId();
            contactGroupTagForm.Contact.ApplicationUserId = userId;
            if (!ModelState.IsValid)
            {
                return View("ContactForm", contactGroupTagForm);
            }
            if (contactGroupTagForm.Contact.Id == 0)
            {
                _context.Contacts.Add(contactGroupTagForm.Contact);
                if (contactGroupTagForm.SelectedGroupTags != null && contactGroupTagForm.SelectedGroupTags.Count() > 0)
                {
                    foreach (int groupId in contactGroupTagForm.SelectedGroupTags)
                    {
                        _context.ContactGroupTags.Add(new ContactGroupTag()
                        {
                            ContactId = contactGroupTagForm.Contact.Id,
                            GroupTagId = groupId
                        });
                    }
                }
            }
            else
            {
                Contact dbContact = _context.Contacts.SingleOrDefault(c => c.Id == contactGroupTagForm.Contact.Id);
                if (dbContact == null)
                {
                    return HttpNotFound();
                }
                dbContact.Name = contactGroupTagForm.Contact.Name;
                dbContact.Email = contactGroupTagForm.Contact.Email;
                dbContact.Phone = contactGroupTagForm.Contact.Phone;
                dbContact.Address = contactGroupTagForm.Contact.Address;
                dbContact.Birthday = contactGroupTagForm.Contact.Birthday;
                IEnumerable<ContactGroupTag> dbContactGroupTags = _context.ContactGroupTags.Where(c => c.ContactId == dbContact.Id);
                _context.ContactGroupTags.RemoveRange(dbContactGroupTags);
                if(contactGroupTagForm.SelectedGroupTags != null && contactGroupTagForm.SelectedGroupTags.Count() > 0)
                {
                    foreach (int groupTagId in contactGroupTagForm.SelectedGroupTags)
                    {
                        _context.ContactGroupTags.Add(new ContactGroupTag { ContactId = dbContact.Id, GroupTagId = groupTagId });
                    }
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Contacts");
        }
        public ActionResult Delete(int param)
        {
            Contact dbContact = _context.Contacts.SingleOrDefault(c => c.Id == param);
            if (dbContact == null)
            {
                return HttpNotFound();
            }
            _context.Contacts.Remove(dbContact);
            IEnumerable<ContactGroupTag> dbContactGroupTags = _context.ContactGroupTags.Where(c => c.ContactId == dbContact.Id);
            _context.ContactGroupTags.RemoveRange(dbContactGroupTags);
            _context.SaveChanges();
            //delete in groupTags db manually
            return RedirectToAction("Index");
        }
    }
}