using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.SlotMachine
{
    public class SpinResultOutputModel
    {
        public Spin SpinResult { get; set; }
        public double  NewBalance { get; set; }
        [Required]
        [Display(Name = "Bet Amount")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number!")]
        public double BetSize { get; set; }
        public string ErrorMessage { get; set; }
    }
}
