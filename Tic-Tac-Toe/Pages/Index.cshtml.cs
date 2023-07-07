using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tic_Tac_Toe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public int Cell { get; set; }

        private Dictionary<int, string> selectedCells = new Dictionary<int, string>(9)
        {
            {1, "" },
            {2, "" },
            {3, "" },
            {4, "" },
            {5, "" },
            {6, "" },
            {7, "" },
            {8, "" },
            {9, "" },
        };

        public Dictionary<int, string> SelectedCells
        {
             get{ return selectedCells; } 
             set{ selectedCells = value; } 
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost(int cell)
        {
            SelectedCells[Cell] = "X";

            Random rnd = new Random();
            int num = rnd.Next(1, 10);

            while (SelectedCells[num] == "X")
            {
                num = rnd.Next(1, 10);
            }

            SelectedCells[num] = "O";

            TempData.Keep("SelectedCells");
        }
    }
}