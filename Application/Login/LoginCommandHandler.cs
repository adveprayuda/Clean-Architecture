using Application.Abstract;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.Login;

internal sealed class LoginCommandHandler
    : ICommandHandler<LoginCommand, string>
{
    private readonly IMemberRepository _memberRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IMemberRepository memberRepository, IJwtProvider jwtProvider)
    {
        _memberRepository = memberRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<string>> Handle(
        LoginCommand request, 
        CancellationToken cancellationToken)
    {
        // Get member
        Result<Email> email = Email.Create(request.Email);

        Member? member = await _memberRepository.GetByEmailAsync(
            email.Value,
            cancellationToken);

        if (member is  null)
        {
            return Result.Failure<string>(
                DomainErrors.Member.InvalidCredentials);
        }

        // Generate jwt
        string token = _jwtProvider.Generate(member);


        // return jwt
        return token;
    }
}