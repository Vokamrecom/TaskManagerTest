using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Application.Tasks.Update;

namespace TaskManager.Pages
{
    public class TaskEditModel : PageModel
    {
        private readonly IMediator _mediator;

        public TaskEditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public EditTaskViewModel Task { get; set; }
        [FromRoute]
        public int Id { get; set; } 
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }

            var request = new Request
            {
                TaskId = Id,
                Title = Task.Title,
                Status = (Enums.TaskStatus)Task.Status,
                Description = Task.Description,
                ActualCompletion = Task.ActualCompletion
            };

            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return Page();
            }

            return RedirectToPage("/Index");
        }

        public class EditTaskViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public TaskManager.Enums.TaskStatus Status { get; set; }
            public DateTime EstimatedCompletion { get; set; }
            public DateTime? ActualCompletion { get; set; }
        }
    }
}
