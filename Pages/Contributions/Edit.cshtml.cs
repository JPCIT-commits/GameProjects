using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameProjects.Data;
using GameProjects.Model;

namespace GameProjects.Pages.Contributions
{
    public class EditModel : PageModel
    {
        private readonly GameProjects.Data.GameProjectsContext _context;

        public EditModel(GameProjects.Data.GameProjectsContext context)
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

            var contribution =  await _context.Contribution.FirstOrDefaultAsync(m => m.Id == id);
            if (contribution == null)
            {
                return NotFound();
            }
            Contribution = contribution;
           ViewData["DeveloperId"] = new SelectList(_context.Set<Developer>(), "Id", "Email");
           ViewData["GameId"] = new SelectList(_context.Set<Game>(), "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contribution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributionExists(Contribution.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContributionExists(int id)
        {
            return _context.Contribution.Any(e => e.Id == id);
        }
    }
}
