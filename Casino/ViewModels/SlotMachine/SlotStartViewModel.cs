using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.SlotMachine
{
    public class SlotStartViewModel
    {
        public double Balance { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number!")]
        public double BetSize { get; set; }
    }
}
