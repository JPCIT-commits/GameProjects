using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameProjects.Data;
using GameProjects.Model;

namespace GameProjects.Pages.Contributions
{
    public class DeleteModel : PageModel
    {
        private readonly GameProjects.Data.GameProjectsContext _context;

        public DeleteModel(GameProjects.Data.GameProjectsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contribution Contribution { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribution = await _context.Contribution.FirstOrDefaultAsync(m => m.Id == id);

            if (contribution is not null)
            {
                Contribution = contribution;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribution = await _context.Contribution.FindAsync(id);
            if (contribution != null)
            {
                Contribution = contribution;
                _context.Contribution.Remove(Contribution);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
