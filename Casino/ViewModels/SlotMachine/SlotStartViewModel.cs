using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.SlotMachine
{
    public class SlotStartViewModel
    {
        [Display(Name = "Update Balance")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number!")]
        public double? BalanceUpdate { get; set; }

        [Required]
        [Display(Name ="Bet Amount")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number!")]
        public double BetSize { get; set; }
    }
}
