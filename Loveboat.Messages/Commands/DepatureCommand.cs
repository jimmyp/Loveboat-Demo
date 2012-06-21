using System;
using Loveboat.ViewModels;
using Microsoft.Build.Framework;
using NServiceBus;

namespace Loveboat.Messages.Commands
{
    public class DepatureCommand : ShipsViewModel, ICommand
    {
        [Required]
        public Guid DepartingShipId { get; set; }

    }
}