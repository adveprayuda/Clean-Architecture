
using Domain.Entities;

namespace Application.Abstract;

public interface IJwtProvider
{
    string Generate(Member member);
}
