using System;
using System.ComponentModel.DataAnnotations;
using Loveboat.ViewModels;
using NServiceBus;

namespace Loveboat.Messages.Commands
{
    public class ArrivalCommand : ShipsViewModel, ICommand
    {
        [Required]
        public Guid ArrivingShipId { get; set; }

        [Required]
        public string ArrivalPort { get; set; }

    }
}