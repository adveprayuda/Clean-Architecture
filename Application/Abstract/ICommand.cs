using MediatR;
using Domain.Shared;

namespace Application.Abstract;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
