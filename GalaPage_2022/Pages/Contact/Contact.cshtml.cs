using GalaPage_2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GalaPage_2022.Pages.Contact
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactoModel Contacto { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Contact/ThankyouPage", new { Contacto.Nombre });
        }
    }
}
