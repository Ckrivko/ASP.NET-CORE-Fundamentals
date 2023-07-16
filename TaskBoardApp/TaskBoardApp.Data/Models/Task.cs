using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskBoardApp.Data.Common;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        public Task()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TaskConstants.TaskMaxTitle,MinimumLength =TaskConstants.TaskMinTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskConstants.TaskMaxDescription, MinimumLength = TaskConstants.TaskMinDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }

        public virtual Board? Board { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        public virtual IdentityUser Owner { get; set; } = null!;


    }
}
