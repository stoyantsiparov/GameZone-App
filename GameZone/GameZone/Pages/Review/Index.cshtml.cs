using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Pages.Review
{
    public class IndexModel : PageModel
    {
        private readonly GameZone.Data.ApplicationDbContext _context;

        public IndexModel(GameZone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reviews != null)
            {
                Review = await _context.Reviews
                    .Include(r => r.Game)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();
            }
        }
    }
}
