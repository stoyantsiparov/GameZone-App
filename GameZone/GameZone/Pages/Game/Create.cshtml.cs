using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Pages.Game
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly GameZone.Data.ApplicationDbContext _context;

        public CreateModel(GameZone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeveloperId"] = new SelectList(_context.Developers, "Id", "Name");
        ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
        ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Models.Game Game { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Games.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
