using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tic_Tac_Toe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public int Cell { get; set; }
        public List<int> SelectedCells { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost(int cell)
        {
            SelectedCells.Add(cell);
            Random rnd = new Random();
            int num = rnd.Next(1, 9);
            while (SelectedCells.Contains(num))
            {
                num = rnd.Next(1, 9);
            }
            SelectedCells.Add(num);
        }
    }
}