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
        public string Win { get; set; }

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
            WinCondition();

            if (Win != null)
            {
                return;
            }
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

            WinCondition();
            if (Win != null)
            {
                return;
            }

            TempData.Set("Selected", SelectedCells);

            TempData.Keep("SelectedCells");


        }
        public void WinCondition()
        {
            if (SelectedCells[1] == "X" && SelectedCells[2] == "X" && SelectedCells[3] == "X")
            {
                Win = "You win";
            }
            if (selectedCells[4] == "X" && SelectedCells[5] == "X" && SelectedCells[6] == "X")
            {
                Win = "You win";
            }
            if (SelectedCells[7] == "X" && SelectedCells[8] == "X" && SelectedCells[9] == "X")
            {
                Win = "You win";
            }
            if (SelectedCells[1] == "X" && SelectedCells[4] == "X" && SelectedCells[7] == "X")
            {
                Win = "You win";
            }
            if (SelectedCells[2] == "X" && SelectedCells[5] == "X" && SelectedCells[8] == "X")
            {
                Win = "You win";
            }
            if (SelectedCells[3] == "X" && SelectedCells[6] == "X" && SelectedCells[9] == "X")
            {
                Win = "You win";
            }
            if (SelectedCells[1] == "X" && SelectedCells[5] == "X" && SelectedCells[9] == "X")
            {
                Win = "You win";
            }
            if (SelectedCells[3] == "X" && SelectedCells[5] == "X" && SelectedCells[7] == "X")
            {
                Win = "You win";
            }





            if (SelectedCells[1] == "O" && SelectedCells[2] == "O" && SelectedCells[3] == "O")
            {
                Win = "You lose";
            }
            if (selectedCells[4] == "O" && SelectedCells[5] == "O" && SelectedCells[6] == "O")
            {
                Win = "You lose";
            }
            if (SelectedCells[7] == "O" && SelectedCells[8] == "O" && SelectedCells[9] == "O")
            {
                Win = "You lose";
            }
            if (SelectedCells[1] == "O" && SelectedCells[4] == "O" && SelectedCells[7] == "O")
            {
                Win = "You lose";
            }
            if (SelectedCells[2] == "O" && SelectedCells[5] == "O" && SelectedCells[8] == "O")
            {
                Win = "You lose";
            }
            if (SelectedCells[3] == "O" && SelectedCells[6] == "O" && SelectedCells[9] == "O")
            {
                Win = "You lose";
            }
            if (SelectedCells[1] == "O" && SelectedCells[5] == "O" && SelectedCells[9] == "O")
            {
                Win = "You lose";
            }
            if (SelectedCells[3] == "O" && SelectedCells[5] == "O" && SelectedCells[7] == "O")
            {
                Win = "You lose";
            }
        }
    }
}