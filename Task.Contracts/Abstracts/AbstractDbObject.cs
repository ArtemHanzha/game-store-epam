using System.ComponentModel.DataAnnotations;

namespace Task.Contracts.Abstracts
{
    public class AbstractDbObject
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}