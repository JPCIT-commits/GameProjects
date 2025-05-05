using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameProjects.Data;
using GameProjects.Model;

namespace GameProjects.Pages.Contributions
{
    public class CreateModel : PageModel
    {
        private readonly GameProjects.Data.GameProjectsContext _context;

        public CreateModel(GameProjects.Data.GameProjectsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeveloperId"] = new SelectList(_context.Set<Developer>(), "Id", "Email");
        ViewData["GameId"] = new SelectList(_context.Set<Game>(), "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Contribution Contribution { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contribution.Add(Contribution);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
