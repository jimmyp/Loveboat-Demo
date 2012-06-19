using System;
using System.ComponentModel.DataAnnotations;
using Loveboat.Models;

namespace Loveboat.Commands
{
    public class ArrivalCommand : ShipsViewModel
    {
        [Required]
        public Guid ArrivingShipId { get; set; }

        [Required]
        public string ArrivalPort { get; set; }

    }
}