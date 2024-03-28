using Domain.Shared;
using MediatR;

namespace Application.Abstract;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}