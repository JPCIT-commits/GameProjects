using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameProjects.Data;
using GameProjects.Model;

namespace GameProjects.Pages.Developers
{
    public class IndexModel : PageModel
    {
        private readonly GameProjects.Data.GameProjectsContext _context;

        public IndexModel(GameProjects.Data.GameProjectsContext context)
        {
            _context = context;
        }

        public IList<Developer> Developer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Developer = await _context.Developer.ToListAsync();
        }
    }
}
