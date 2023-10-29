using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;

namespace RazorPagesTutorial.Pages.Person
{
    public class DisplayAll : PageModel
    {
        private readonly AppDbContext _ctx;

        public DisplayAll(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Data.Person> People { get; set; }
        public IActionResult OnGet()
        {
            People = _ctx.Person.ToList(); 
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var person = await _ctx.Person.FindAsync(id);
            if(person == null)
                return NotFound();
            try
            {
                _ctx.Person.Remove(person);
                _ctx.SaveChanges();
                TempData["success"] = "Deleted Successfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error has occured";
            }
            return RedirectToPage();
        }
    }
}
