using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_DotNet_Dojo.ViewModels;

namespace Project_DotNet_Dojo.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Model { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("../Index");
                }

                ModelState.AddModelError("", "Email or Password incorrect");
            }
            var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

            return Page();
        }
    }
}
