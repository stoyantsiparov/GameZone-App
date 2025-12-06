using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Pages.Game
{
    public class DetailsModel : PageModel
    {
        private readonly GameZone.Data.ApplicationDbContext _context;

        public DetailsModel(GameZone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Game Game { get; set; } = default!;

        [BindProperty]
        public Models.Review NewReview { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Genre)     
                .Include(g => g.Developer) 
                .Include(g => g.Platform)  
                .Include(g => g.Reviews)   
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }
            else
            {
                Game = game;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Challenge();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            NewReview.GameId = id;
            NewReview.UserName = User.Identity.Name!;
            NewReview.CreatedAt = DateTime.Now;

            _context.Reviews.Add(NewReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = id });
        }
    }
}