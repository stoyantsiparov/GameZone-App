using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameZone.Data;
using GameZone.Models;

namespace GameZone.Pages.Developer
{
    public class IndexModel : PageModel
    {
        private readonly GameZone.Data.ApplicationDbContext _context;

        public IndexModel(GameZone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Developer> Developer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Developer = await _context.Developers.ToListAsync();
        }
    }
}
