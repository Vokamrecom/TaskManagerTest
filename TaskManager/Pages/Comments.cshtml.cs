using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Application.Comments.Get;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.Pages
{
    public class CommentsModel : PageModel
    {
        private readonly IMediator _mediator;

        public CommentsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public string NewComment { get; set; }
        public string TaskTitle { get; set; }
        public List<CommentDto> Comments { get; set; }

        public async Task OnGetAsync(int taskId)
        {
            var result = await _mediator.Send(new Application.Comments.Get.Request { TaskId = taskId });
            //TaskTitle = result.Title;
            Comments = result.Comments;
        }

        public async Task<IActionResult> OnPostAsync(int taskId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _mediator.Send(new Application.Comments.Add.Request { TaskId = taskId, Content = NewComment });
            return RedirectToPage(new { taskId });
        }
    }

}
