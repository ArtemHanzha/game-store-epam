using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task.Contracts.Abstracts;

namespace Task.Contracts.Modes
{
    public class Comment : AbstractDbObject
    {
        public string Name { get; set; }

        public string Body { get; set; }

        public string AuthorName { get; set; }

        [Required]
        public virtual Game Game { get; set; }

        public ICollection<Comment> Replies { get; set; }

        public Comment Parrent { get; set; }
    }
}