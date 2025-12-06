using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Using our custom PaginatedList instead of a standard List
        public PaginatedList<Models.Game> Game { get; set; } = default!;

        // Variables for sorting
        public string TitleSort { get; set; } = null!;
        public string DateSort { get; set; } = null!;
        public string PriceSort { get; set; } = null!;
        public string CurrentSort { get; set; } = null!;

        // Variables for filtering
        public string CurrentFilter { get; set; } = null!;
        public string CurrentGenre { get; set; } = null!;
        public SelectList Genres { get; set; } = null!;

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, string currentGenre, int? pageIndex)
        {
            CurrentSort = sortOrder;

            // Sorting configuration
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            CurrentGenre = currentGenre;

            // 1. Fetch all games from the database
            IQueryable<Models.Game> gamesIQ = _context.Games
                .Include(g => g.Developer)
                .Include(g => g.Genre)
                .Include(g => g.Platform);

            // 2. FILTERING BY NAME (Search)
            if (!string.IsNullOrEmpty(searchString))
            {
                gamesIQ = gamesIQ.Where(s => s.Title.Contains(searchString));
            }

            // 3. FILTERING BY GENRE
            // Populate the genre dropdown menu
            IQueryable<string> genreQuery = _context.Genres.OrderBy(x => x.Name).Select(x => x.Name);
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            // Apply genre filter if selected
            if (!string.IsNullOrEmpty(currentGenre))
            {
                gamesIQ = gamesIQ.Where(x => x.Genre!.Name == currentGenre);
            }

            // 4. SORTING LOGIC
            switch (sortOrder)
            {
                case "title_desc":
                    gamesIQ = gamesIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    gamesIQ = gamesIQ.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    gamesIQ = gamesIQ.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "Price":
                    gamesIQ = gamesIQ.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    gamesIQ = gamesIQ.OrderByDescending(s => s.Price);
                    break;
                default:
                    gamesIQ = gamesIQ.OrderBy(s => s.Title);
                    break;
            }

            // 5. PAGINATION (5 items per page)
            int pageSize = 5;
            Game = await PaginatedList<Models.Game>.CreateAsync(gamesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}