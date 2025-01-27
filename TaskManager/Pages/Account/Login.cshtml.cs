using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Application.Users.Login;

namespace TaskManager.Pages.Account;

public class LoginModel : PageModel
{
    private readonly IMediator _mediator;

    public LoginModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }
    public string Message { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        var result = await _mediator.Send(new Request
        {
            Username = Username,
            Password = Password
        });

        Message = result.Message;
        if (result.Success)
        {
            return RedirectToPage("/Index");
        }

        return Page();
    }
}