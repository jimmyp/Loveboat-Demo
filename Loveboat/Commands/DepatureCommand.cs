using System;
using System.ComponentModel.DataAnnotations;
using Loveboat.Models;

namespace Loveboat.Commands
{
    public class DepatureCommand : ShipsViewModel
    {
        [Required]
        public Guid DepartingShipId { get; set; }

    }
}