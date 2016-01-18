using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Web.Models;
using System;
using System.Net.Http;

namespace Web.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Messages
        public IActionResult Index()
        {
            return View(_context.Message.ToList());
        }

        // GET: Messages/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Message message = _context.Message.Single(m => m.ID == id);
            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Message.Add(message);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Message message = _context.Message.Single(m => m.ID == id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            [Bind("MsgText")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Update(message);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Message message = _context.Message.Single(m => m.ID == id);
            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Message message = _context.Message.Single(m => m.ID == id);
            _context.Message.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void RecievePostData(string msg)
        {
            _context.Message.AddRange(
                new Message
                {
                    MsgText = msg,
                    TimeStamp = DateTime.UtcNow
                }
            );
            _context.SaveChanges();
        }
    }
}
