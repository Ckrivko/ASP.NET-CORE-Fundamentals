using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Interface;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext dbContext;

        public TaskService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task AddAsync(string ownerId, TaskFormModel model)
        {
            var task = new TaskBoardApp.Data.Models.Task()
            {
                Title = model.Title,
                Description = model.Description,
                OwnerId = ownerId,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,

            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TaskViewModel> DeleteAsync(string id)
        {
            var result = await this.dbContext
                .Tasks
                .FirstAsync(t => t.Id.ToString() == id);


            var taskModel = new TaskViewModel()
            {
                Id = result.Id.ToString(),
                Title = result.Title,
                Description = result.Description,
            };

            return taskModel;

        }

        public async Task DeleteAsync(TaskViewModel model)
        {
            var result = await this.dbContext
                 .Tasks
                 .FirstAsync(t => t.Id.ToString() == model.Id);

            this.dbContext.Tasks.Remove(result);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<TaskFormModel> EditAsync(string id)
        {
            var task = await this.dbContext
                 .Tasks
                 .FirstAsync(t => t.Id.ToString() == id);

            var taskFormModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,

            };
            return taskFormModel;

        }

        public async Task EditAsync(string id, TaskFormModel model)
        {
            var task = await this.dbContext
                 .Tasks
                 .FirstAsync(t => t.Id.ToString() == id);

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;
            
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<TaskDetailsModel> GetForDetailsByIdAsync(string id)
        {
            TaskDetailsModel viewModel = await this.dbContext
                .Tasks
                .Select(t => new TaskDetailsModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName,
                    CreatedOn = t.CreatedOn.ToString("f"),
                    Board = t.Board.Name

                }).FirstAsync(a => a.Id == id);

            return viewModel;

        }


    }
}
