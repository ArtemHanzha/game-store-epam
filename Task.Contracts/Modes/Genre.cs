using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task.Contracts.Abstracts;

namespace Task.Contracts.Modes
{
    public class Genre : AbstractDbObject
    {
        [Required]
        public string Name { get; set; } //TODO: make this uniquie

        public Genre Parrent { get; set; }

        public ICollection<Game> Games { get; set; }

        public IEnumerable<Genre> SubGenres { get; set; }
    }
}