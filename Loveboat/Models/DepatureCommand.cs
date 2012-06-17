using System;
using System.ComponentModel.DataAnnotations;

namespace Loveboat.Models
{
    public class DepatureCommand : ShipsViewModel
    {
        [Required]
        public Guid DepartingShipId { get; set; }
    }
}