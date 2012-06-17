using System;

namespace Loveboat.Models
{
    public class ShipViewModel
    {
        public ShipViewModel(string name, string location)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (location == null) throw new ArgumentNullException("location");
            Id = Guid.NewGuid();
            Name = name;
            Location = location;
        }

        public Guid Id { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }
    }
}