using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Interface
{
    public interface ITaskService
    {

        Task AddAsync(string ownerId, TaskFormModel model);

        Task<TaskDetailsModel> GetForDetailsByIdAsync(string id);

        Task<TaskViewModel> DeleteAsync(string id);

        Task DeleteAsync(TaskViewModel model);

        Task<TaskFormModel> EditAsync(string id);

        Task EditAsync(string id,TaskFormModel model);

       
    }
}

