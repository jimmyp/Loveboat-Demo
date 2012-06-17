using System;
using System.ComponentModel.DataAnnotations;

namespace Loveboat.Models
{
    public class ArrivalCommand : ShipsViewModel
    {
        [Required]
        public Guid ArrivingShipId { get; set; }

        [Required]
        public string ArrivalPort { get; set; }
    }
}