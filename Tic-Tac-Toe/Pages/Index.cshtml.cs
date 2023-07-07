using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Tic_Tac_Toe.Helpers;

namespace Tic_Tac_Toe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public int Cell { get; set; }

        private Dictionary<int, string> selectedCells;

        public Dictionary<int, string> SelectedCells
        {
            get
            {
                if (selectedCells == null)
                {
                    selectedCells = new Dictionary<int, string>(9)
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
                }

                return selectedCells;
            }
            set
            {
                selectedCells = value;
            }
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            selectedCells = null;
        }

        public void OnPost(int cell)
        {
            SelectedCells = TempData.Get<Dictionary<int, string>>("Selected");

            SelectedCells[Cell] = "X";

            Random rnd = new Random();
            int num = rnd.Next(1, 10);

            while (SelectedCells[num] == "X" || SelectedCells[num] == "O")
            {
                num = rnd.Next(1, 10);

                if (!SelectedCells.ContainsValue(""))
                {
                    break;
                }
            }
            if (SelectedCells[num] != "X" && SelectedCells[num] != "O")
            {

                SelectedCells[num] = "O";
            }

            TempData.Set("Selected", SelectedCells);

            TempData.Keep("SelectedCells");
        }
    }
}