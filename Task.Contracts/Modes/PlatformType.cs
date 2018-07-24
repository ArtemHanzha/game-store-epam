using System.Collections;
using System.Collections.Generic;
using Task.Contracts.Abstracts;

namespace Task.Contracts.Modes
{
    public class PlatformType : AbstractDbObject
    {
        public string Type { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}