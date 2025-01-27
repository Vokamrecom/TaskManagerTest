using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Application.Comments.Get;
using TaskManager.Application.Tasks.Get;

namespace TaskManager.Pages
{
    public class TaskDetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public TaskDetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public TaskManager.Application.Tasks.Get.Response Task { get; set; }

        public List<CommentDto> Comments { get; set; } 

        [BindProperty]
        public string NewComment { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            Task = await _mediator.Send(new TaskManager.Application.Tasks.Get.Request { TaskId = Id });
            if (Task == null)
            {
                return NotFound();
            }


            var result = await _mediator.Send(new Application.Comments.Get.Request { TaskId = Id });
            //TaskTitle = result.Title;
            Comments = result.Comments;

            return Page();
        }

        public async Task<IActionResult> OnPostAddCommentAsync()
        {
            if (!ModelState.IsValid)
            {
                return await OnGetAsync(); 
            }

 
            var response = await _mediator.Send(new TaskManager.Application.Comments.Add.Request
            {
                TaskId = Id,
                Content = NewComment
            });

            if (!response.Success)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return await OnGetAsync();
            }

            return RedirectToPage(new { id = Id });
        }
    }
}
