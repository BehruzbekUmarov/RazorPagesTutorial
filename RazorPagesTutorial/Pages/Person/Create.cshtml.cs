using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;

namespace RazorPagesTutorial.Pages.Person
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _appDb;

        public CreateModel(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        [BindProperty]
        public Data.Person Person { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                if(Person == null)
                    return NotFound();
                _appDb.Person.Add(Person);
                _appDb.SaveChanges();
                TempData["success"] = "Saved Seccessfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error has occured";
            }
            return RedirectToPage();
        }
    }
}
