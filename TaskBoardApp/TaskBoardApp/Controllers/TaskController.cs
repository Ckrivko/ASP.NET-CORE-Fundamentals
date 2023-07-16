using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Interface;
using TaskBoardApp.Web.ViewModels.Task;

using TaskBoardApp.Extentions;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new TaskFormModel()
            {
                Boards = await this.boardService.AllForSelectAsync()
            };


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await this.boardService.AllForSelectAsync();
                return this.View(model);
            }

            var bordExist = await boardService.ExistByIdAsync(model.BoardId);

            if (!bordExist)
            {
                model.Boards = await this.boardService.AllForSelectAsync();
                ModelState.AddModelError(nameof(model.BoardId), "Select board does not exist");
                return this.View(model);
            }

            string currUserId = this.User.GetId();

            await taskService.AddAsync(currUserId, model);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]        
        public async Task<IActionResult> Details(string Id)
        {
            try
            {
                var viewModel = await taskService.GetForDetailsByIdAsync(Id);
                return View(viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Board");
            }

        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await taskService.EditAsync(id);

            model.Boards = await boardService.AllForSelectAsync();
               return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await this.boardService.AllForSelectAsync();
                return this.View(model);
            }

            var bordExist = await boardService.ExistByIdAsync(model.BoardId);

            if (!bordExist)
            {
                model.Boards = await this.boardService.AllForSelectAsync();
                ModelState.AddModelError(nameof(model.BoardId), "Select board does not exist");
                return this.View(model);
            }

            await taskService.EditAsync(id,model);

            return RedirectToAction("All", "Board");
        }



        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await taskService.DeleteAsync(id);     
               
                return View(model);                       
           
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            await taskService.DeleteAsync(model);

            return RedirectToAction("All", "Board");

        }
    }
}
