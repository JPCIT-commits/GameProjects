using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameProjects.Data;
using GameProjects.Model;
using System.Diagnostics;

namespace GameProjects.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly GameProjects.Data.GameProjectsContext _context;

        public CreateModel(GameProjects.Data.GameProjectsContext context)
        {
            _context = context;
        }

        // Property to hold the Enum values
        public List<string> StageList { get; set; } = new List<string>();

        public IActionResult OnGet()
        {
            StageList = Enum.GetNames(typeof(GameProjects.Model.Progress)).ToList();
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Game.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
