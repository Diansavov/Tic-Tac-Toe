﻿using Microsoft.AspNetCore.Mvc;
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

        public int Line { get; set; }

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

            if (SelectedCells[Cell] == "X" || SelectedCells[Cell] == "O")
            {

                TempData.Set("Selected", SelectedCells);

                TempData.Keep("SelectedCells");
                return;
            }
            else if (SelectedCells[Cell] == "")
            {
                SelectedCells[Cell] = "X";
            }

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
                Line = 1;
                return;
            }
            else if (selectedCells[4] == "X" && SelectedCells[5] == "X" && SelectedCells[6] == "X")
            {
                Win = "You win";
                Line = 2;
                return;
            }
            else if (SelectedCells[7] == "X" && SelectedCells[8] == "X" && SelectedCells[9] == "X")
            {
                Win = "You win";
                Line = 3;
                return;
            }
            else if (SelectedCells[1] == "X" && SelectedCells[4] == "X" && SelectedCells[7] == "X")
            {
                Win = "You win";
                Line = 4;
                return;
            }
            else if (SelectedCells[2] == "X" && SelectedCells[5] == "X" && SelectedCells[8] == "X")
            {
                Win = "You win";
                Line = 5;
                return;
            }
            else if (SelectedCells[3] == "X" && SelectedCells[6] == "X" && SelectedCells[9] == "X")
            {
                Win = "You win";
                Line = 6;
                return;
            }
            else if (SelectedCells[1] == "X" && SelectedCells[5] == "X" && SelectedCells[9] == "X")
            {
                Win = "You win";
                Line = 7;
                return;
            }
            else if (SelectedCells[3] == "X" && SelectedCells[5] == "X" && SelectedCells[7] == "X")
            {
                Win = "You win";
                Line = 8;
                return;
            }





            if (SelectedCells[1] == "O" && SelectedCells[2] == "O" && SelectedCells[3] == "O")
            {
                Win = "You lose";
                Line = 1;

                return;
            }
            else if (selectedCells[4] == "O" && SelectedCells[5] == "O" && SelectedCells[6] == "O")
            {
                Win = "You lose";
                Line = 2;

                return;
            }
            else if (SelectedCells[7] == "O" && SelectedCells[8] == "O" && SelectedCells[9] == "O")
            {
                Win = "You lose";
                Line = 3;

                return;
            }
            else if (SelectedCells[1] == "O" && SelectedCells[4] == "O" && SelectedCells[7] == "O")
            {
                Win = "You lose";
                Line = 4;

                return;
            }
            else if (SelectedCells[2] == "O" && SelectedCells[5] == "O" && SelectedCells[8] == "O")
            {
                Win = "You lose";
                Line = 5;

                return;
            }
            else if (SelectedCells[3] == "O" && SelectedCells[6] == "O" && SelectedCells[9] == "O")
            {
                Win = "You lose";
                Line = 6;

                return;
            }
            else if (SelectedCells[1] == "O" && SelectedCells[5] == "O" && SelectedCells[9] == "O")
            {
                Win = "You lose";
                Line = 7;

                return;
            }
            else if (SelectedCells[3] == "O" && SelectedCells[5] == "O" && SelectedCells[7] == "O")
            {
                Win = "You lose";
                Line = 8;
                return;
            }

            if (!SelectedCells.Values.Contains(""))
            {
                Win = "Draw";
                return;
            }

            
        }
    }
}