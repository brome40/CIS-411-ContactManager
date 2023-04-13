using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        //Pass and store context data
        private ContactContext context { get; set; }
        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(c => c.Category)
                .OrderBy(c => c.FirstName).ToList();   
            return View(contacts);
        }
    }
}