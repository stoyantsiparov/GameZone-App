using GameZone.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Review> RecentReviews { get; set; } = new List<Models.Review>();

        public int GamesCount { get; set; }
        public int ReviewsCount { get; set; }
        public int DevelopersCount { get; set; }

        public async Task OnGetAsync()
        {
            RecentReviews = await _context.Reviews
                .Include(r => r.Game)
                .OrderByDescending(r => r.CreatedAt)
                .Take(3)
                .ToListAsync();

            GamesCount = await _context.Games.CountAsync();
            ReviewsCount = await _context.Reviews.CountAsync();
            DevelopersCount = await _context.Developers.CountAsync();
        }
    }
}