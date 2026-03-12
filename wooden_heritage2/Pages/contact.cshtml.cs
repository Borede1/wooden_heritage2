using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wooden_heritage2.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Reservation { get; set; }

        [BindProperty]
        public string CheckIn { get; set; }

        [BindProperty]
        public string CheckOut { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public string SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SuccessMessage = "Thank you " + Name + "! Your message has been sent.";
            return Page();
        }
    }
}