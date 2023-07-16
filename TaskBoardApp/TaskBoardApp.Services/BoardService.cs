using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Interface;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    public class BoardService : IBoardService
    {
        private readonly TaskBoardDbContext dbContext;

        public BoardService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<BoardAllViewModel>> AllAsync()
        {
            var result = await dbContext.
                Boards
                .Select(b => new BoardAllViewModel
                {
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel
                    {
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName,
                        Id = t.Id.ToString()

                    }).ToArray()

                })
                .ToArrayAsync();

            return result;
        }

        public async Task<IEnumerable<BoardAllViewModel>> AllAsyncByOwner(string id)
        {
            var result = await dbContext.
                  Boards
                  .Select(b => new BoardAllViewModel
                  {
                      Name = b.Name,
                      Tasks = b.Tasks
                      .Where(t => t.OwnerId == id)
                      .Select(t => new TaskViewModel
                      {
                          Title = t.Title,
                          Description = t.Description,
                          Owner = t.Owner.UserName,
                          Id = t.Id.ToString()

                      }).ToArray()

                  })
                  .ToArrayAsync();

            return result;
        }

        public async Task<IEnumerable<BoardSelectModel>> AllForSelectAsync()
        {
            var allBoards = await dbContext.Boards
                .Select(b => new BoardSelectModel
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToArrayAsync();

            return allBoards;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            var result = await dbContext.Boards
                .AnyAsync(b => b.Id == id);

            return result;
        }

       
    }
}
