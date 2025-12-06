using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Pages.Platform
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
        public Models.Platform Platform { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platform = await _context.Platforms.FirstOrDefaultAsync(m => m.Id == id);

            if (platform == null)
            {
                return NotFound();
            }
            else
            {
                Platform = platform;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platform = await _context.Platforms.FindAsync(id);
            if (platform != null)
            {
                Platform = platform;
                _context.Platforms.Remove(Platform);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
