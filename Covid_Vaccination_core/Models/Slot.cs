using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Models
{
    public class Slot
    {
        public int SlotId { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Doseno { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Pinno { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public string VaccineType { get; set; }
        public User User { get; set; }
        public string status { get; set; }
    }
}
