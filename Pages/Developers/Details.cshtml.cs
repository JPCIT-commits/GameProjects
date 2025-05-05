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
    public class DetailsModel : PageModel
    {
        private readonly GameProjects.Data.GameProjectsContext _context;

        public DetailsModel(GameProjects.Data.GameProjectsContext context)
        {
            _context = context;
        }

        public Developer Developer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer.FirstOrDefaultAsync(m => m.Id == id);

            if (developer is not null)
            {
                Developer = developer;

                return Page();
            }

            return NotFound();
        }
    }
}
