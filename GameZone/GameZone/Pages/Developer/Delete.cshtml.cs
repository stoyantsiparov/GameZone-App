using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Pages.Developer
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly GameZone.Data.ApplicationDbContext _context;

        public DeleteModel(GameZone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Developer Developer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers.FirstOrDefaultAsync(m => m.Id == id);

            if (developer == null)
            {
                return NotFound();
            }
            else
            {
                Developer = developer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers.FindAsync(id);
            if (developer != null)
            {
                Developer = developer;
                _context.Developers.Remove(Developer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
