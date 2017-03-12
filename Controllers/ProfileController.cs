using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using StartDate.Models;

namespace StartDate.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProfileController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile  = await _context.Profiles.SingleOrDefaultAsync(m=>m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile  = await _context.Profiles.SingleOrDefaultAsync(m=>m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> Edit(int id, [BindAttribute("Id, DisplayName, Birthday, Height, Description, Occupation, ProfilePicture, Smoking")] Profile profile)
        {
            if(id != profile.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try{
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {
                    if (!ProfileExists(profile.Id))
                    {
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile  = await _context.Profiles.SingleOrDefaultAsync(m=>m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }
        [HttpPost, ActionNameAttribute("Delete")]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var profile  = await _context.Profiles.SingleOrDefaultAsync(m=>m.Id == id);
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfileExisted(int id){
            return _context.Profiles.Any(m=>m.Id == id);
        }
    }
}
