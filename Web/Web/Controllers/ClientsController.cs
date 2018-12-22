using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientEFRepository _clientEFRepository;

        public ClientsController(IClientEFRepository clientEFRepository) 
            => _clientEFRepository = clientEFRepository;

        // GET: Client
        public IActionResult Index() 
            => View(_clientEFRepository.GetAll());

        // GET: Client/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var client = _clientEFRepository.GetById(id);

            if (client == null)
                return NotFound();

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create() 
            => View();

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.Id = Guid.NewGuid();
                _clientEFRepository.Add(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var client = _clientEFRepository.GetById(id);

            if (client == null)
                return NotFound();

            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name")] Client client)
        {
            if (id != client.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _clientEFRepository.Update(client);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // GET: Client/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var client = _clientEFRepository.GetById(id);

            if (client == null)
                return NotFound();

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var client = _clientEFRepository.GetById(id);
            _clientEFRepository.Remove(client);

            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(Guid id) 
            => _clientEFRepository.GetById(id) != null;
    }
}
