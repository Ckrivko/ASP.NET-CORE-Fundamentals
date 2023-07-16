using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.Common.TaskConstants;


namespace TaskBoardApp.Web.ViewModels.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle
            ,ErrorMessage ="Title should be at least {2} characters long")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskMaxDescription, MinimumLength = TaskMinDescription
            , ErrorMessage = "Description should be at least {2} long")]
        public string Description { get; set; } = null!;

        [Display(Name ="Board")]
        public int BoardId { get; set; }

        public IEnumerable<BoardSelectModel>? Boards { get; set; } 
    }
}
