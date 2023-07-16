using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Interface
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardAllViewModel>> AllAsync();
        Task<IEnumerable<BoardAllViewModel>> AllAsyncByOwner(string id);

        Task<IEnumerable<BoardSelectModel>> AllForSelectAsync();

        Task<bool> ExistByIdAsync(int id);
 
     
    }
}
