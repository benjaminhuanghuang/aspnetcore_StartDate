using System;
using System.IO;   // For file upload
using Microsoft.AspNetCore.Http;   // For file upload
using Microsoft.AspNetCore.Hosting;  // For file upload
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using StartDate.Models;
using StartDate.Models.Identity;


namespace StartDate.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDBContext _context;
        private UserManager<ApplicationUser> _userManager;

        private IHostingEnvironment _enviroment;

        public ProfileController(ApplicationDBContext context, 
                                    UserManager<ApplicationUser> userManager,
                                    IHostingEnvironment enviroment)
        {
            _context = context;
            _userManager = userManager;
            _enviroment = enviroment;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        public IActionResult Search()
        {
            ProfileSearchViewModel vm = new ProfileSearchViewModel();
            vm.MinAge = 18;
            vm.MaxAge = 85;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Search(ProfileSearchViewModel vm)
        {
            List<ProfileSearchResultViewModel> result = new List<ProfileSearchResultViewModel>();

            if (ModelState.IsValid)
            {
                DateTime minDate = DateTime.Today.AddYears(-vm.MaxAge);
                DateTime maxDate = DateTime.Today.AddYears(-vm.MinAge);
                
                result = (from p in _context.Profiles
                         where p.Gender == vm.Gender
                             &&p.Height > vm.MinHeight && p.Height < vm.MaxHeight
                             &&p.Birthday > minDate && p.Birthday < maxDate
                             && (!vm.NoSmoking|| (vm.NoSmoking && p.Smoking==SmokerType.No))
                         select new ProfileSearchResultViewModel
                         {
                            Description = p.Description,
                            Id = p.Id,
                            ProfilePicture = $"(p.User.Id)/(p.ProfilePicture)",
                            Gender = p.Gender,  
                            Smoking = p.Smoking,
                            Occupation = p.Occupation,
                            DisplayName = p.DisplayName,
                            Height = p.Height,
                            Age = calculateAge(p.Birthday)
                         }).ToList(); 
                             
            }

            return View("Result", result); //show result in "Result" view
        }

        private int calculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age --;
            }
            return age;
        }

        public async Task<IActionResult> Edit()
        {
            ApplicationUser currUser = await _userManager.GetUserAsync(User);
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == currUser.ProfileId);
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> Edit([BindAttribute("Id, DisplayName, Birthday, Height, Description, Occupation, ProfilePicture, Smoking, ProfilePicture")] Profile profile, IFormFile profilePicutureFile)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currUser = await _userManager.GetUserAsync(User);
                if (profilePicutureFile != null)
                {
                    string uploadPath = Path.Combine(_enviroment.WebRootPath, "uploads");
                    string userPath = Path.Combine(uploadPath, currUser.Id);
                    Directory.CreateDirectory(userPath);

                    string fileName = Path.GetFileName(profilePicutureFile.FileName);
                    using(FileStream fs = new FileStream(Path.Combine(userPath, fileName),FileMode.Create))
                    {
                        await profilePicutureFile.CopyToAsync(fs);
                    }
                    profile.ProfilePicture = fileName;
                }
                _context.Update(profile);
                await _context.SaveChangesAsync();
            }
            return View(profile);
        }
        /*
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == id);
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
            if (id != profile.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!ProfileExisted(profile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
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
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == id);
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
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == id);
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfileExisted(int id)
        {
            return _context.Profiles.Any(m => m.Id == id);
        }
        */
    }
}
