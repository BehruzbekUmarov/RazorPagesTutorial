using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;

namespace RazorPagesTutorial.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _appDb;

        public EditModel(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        [BindProperty]
        public Data.Person Person { get; set; }
        public IActionResult OnGet(int id)
        {
            var person = _appDb.Person.Find(id);
            if (person == null)
                return NotFound();
            Person = person;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                if (Person == null)
                    return NotFound();
                _appDb.Person.Update(Person);
                _appDb.SaveChanges();
                TempData["success"] = "Saved Seccessfully";
                return RedirectToPage("DisplayAll");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error has occured";
                return Page();
            }
        }
    }
}
