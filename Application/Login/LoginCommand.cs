using Application.Abstract;

namespace Application.Login;

public record LoginCommand(string Email) : ICommand<string>;