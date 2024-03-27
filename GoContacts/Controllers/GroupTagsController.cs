using GoContacts.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoContacts.Controllers
{
    public class GroupTagsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GroupTagsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index","Contacts");
        }
        public ActionResult Create() 
        {
            GroupTag groupTag = new GroupTag();
            return View("GroupTagForm", groupTag);
        }
        public ActionResult Edit(int param)
        {
            GroupTag groupTag = _context.GroupTags.SingleOrDefault(g => g.Id == param);
            if (groupTag == null)
            {
                return HttpNotFound();
            }
            groupTag.ApplicationUserId = "zxghop";
            return View("GroupTagForm", groupTag);
        }
        public ActionResult Save(GroupTag groupTag)
        {
            groupTag.ApplicationUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return View("GroupTagForm", groupTag);
            }
            if (groupTag.Id == 0)
            {
                _context.GroupTags.Add(groupTag);
            }
            else
            {
                GroupTag dbGroupTag = _context.GroupTags.SingleOrDefault(g => g.Id == groupTag.Id);
                if (dbGroupTag == null)
                {
                    return HttpNotFound();
                }
                dbGroupTag.Name = groupTag.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Contacts");
        }
        public ActionResult Delete(int param)
        {
            GroupTag groupTag = _context.GroupTags.SingleOrDefault(c => c.Id == param);
            if (groupTag == null)
            {
                return HttpNotFound();
            }
            _context.GroupTags.Remove(groupTag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}