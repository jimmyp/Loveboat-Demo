using System;
using System.ComponentModel.DataAnnotations;
using Loveboat.ViewModels;
using NServiceBus;

namespace Loveboat.Messages.Commands
{
    public class DepatureCommand : ShipsViewModel, ICommand
    {
        [Required]
        public Guid DepartingShipId { get; set; }

    }
}