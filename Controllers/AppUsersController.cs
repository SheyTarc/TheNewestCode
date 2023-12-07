using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LETSGO.Data;
using LETSGO.Models;
using System.Security.Claims;

namespace LETSGO.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppUsers

        // GET: AppUsers/Details/5
        public IActionResult Invest()
        {
            return View();
        }

        // GET: AppUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,FullName,IdentityType,IdentityCardNum,PassportNum,BirthDate,Email,PhoneNumber,Address,City,PosCode")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                appUser.FullName = $"{appUser.FirstName} {appUser.LastName}";

                _context.Add(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Invest));
            }
            return View(appUser);
        }

        // GET: AppUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppUser == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUser.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,IdentityCardNum,BirthDate,Email,PhoneNumber,Address,City,PosCode")] AppUser appUser)
        {
            if (id != appUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUsers/Delete/5
        // GET: AppUsers/Display

        public IActionResult Display(int userId)
        {
            // Retrieve the inserted data from the database using the provided userId
            var user = _context.AppUser.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                // Handle the case where the user with the specified ID is not found
                return NotFound();
            }

            // Pass the retrieved data to the view
            return View();
        }
    }
}
