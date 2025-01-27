using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public List<TaskManager.Application.Tasks.Get.TaskDto> Tasks { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _mediator.Send(new TaskManager.Application.Tasks.GetAll.Request());
            Tasks = result.Tasks;
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
             await _mediator.Send(new TaskManager.Application.Tasks.Delete.Request { TaskId = id });

            return RedirectToPage();
        }
    }
}
