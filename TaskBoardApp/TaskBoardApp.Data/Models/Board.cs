using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data.Common;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BoardConstants.BoardMaxName,MinimumLength =BoardConstants.BoardMinName)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
