using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task.Contracts.Abstracts;

namespace Task.Contracts.Modes
{
    public class Game : AbstractDbObject
    {
        [Required]
        public string Key { get; set; } //TODO: make this uniquie

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<PlatformType> Platforms { get; set; }
    }
}
