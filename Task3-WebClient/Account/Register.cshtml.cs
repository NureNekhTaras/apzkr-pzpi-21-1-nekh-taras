using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MusicSchool.Data;
using MusicSchool.Models;

namespace MusicSchool.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserRepository _userRepository;

        public RegisterModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingUser = await _userRepository.GetUserByLoginAsync(User.Login);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "User with this login already exists.");
                return Page();
            }

            // Hash password before saving
            User.Password = BCrypt.Net.BCrypt.HashPassword(User.Password);

            await _userRepository.AddUserAsync(User);

            return RedirectToPage("/Account/Login");
        }
    }
}
