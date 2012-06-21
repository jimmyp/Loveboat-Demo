using System;
using Loveboat.ViewModels;
using Microsoft.Build.Framework;
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