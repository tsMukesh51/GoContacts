//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using GoContacts.Models;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GoContacts.UnitTests.ContactsController
{
    [TestFixture]
    public class ContactsControllerTests
    {
        //private Mock<ApplicationDbContext> _context;
        //private ContactsController _controller;

        //[SetUp]
        //public void SetUp()
        //{
        //    _context = new Mock<ApplicationDbContext>();
        //    _controller = new ContactsController(_context.Object);

        //    // Mock the User.Identity.GetUserId() method
        //    var mockIdentity = new Mock<IIdentity>();
        //    mockIdentity.Setup(x => x.GetUserId()).Returns("test-user-id");
        //    var principal = new Mock<IPrincipal>();
        //    principal.Setup(x => x.Identity).Returns(mockIdentity.Object);
        //    _controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = principal.Object } };
        
    }
}
