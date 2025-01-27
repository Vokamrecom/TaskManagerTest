using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TaskManager.Application.Tasks.Create;

namespace TaskManager.Pages
{

    public class CreateTaskModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateTaskModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime EstimatedCompletion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _mediator.Send(new Request
            {
                Title = Title,
                Description = Description,
                EstimatedCompletion = EstimatedCompletion
            });

            return RedirectToPage("/Index");
        }
    }



}
