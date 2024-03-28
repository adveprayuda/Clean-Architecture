using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Application.Login;
using Domain.Shared;
using Application.Members.GetMembersById;
using Application.Contracts;
using Application.Members.CreateMember;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class MembersController : ApiController
{
    public MembersController(ISender sender)
        : base(sender)
    {
    }

    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMemberById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetMemberByIdQuery(id);

        Result<MemberResponse> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginMember(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(request.Email);

        Result<string> tokenResult = await Sender.Send(
            command,
            cancellationToken);

        if (tokenResult.IsFailure)
        {
            return HandleFailure(tokenResult);
        }

        return Ok(tokenResult.Value);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterMember(
        [FromBody] RegisterMemberRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateMemberCommand(
            request.Email,
            request.FirstName,
            request.LastName);

        Result<Guid> result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            nameof(GetMemberById),
            new { id = result.Value },
            result.Value);
    }

    //[HttpPut("{id:guid}")]
    //public async Task<IActionResult> UpdateMember(
    //    Guid id,
    //    [FromBody] UpdateMemberRequest request,
    //    CancellationToken cancellationToken)
    //{
    //    var command = new UpdateMemberCommand(
    //        id,
    //        request.FirstName,
    //        request.LastName);

    //    Result result = await Sender.Send(
    //        command,
    //        cancellationToken);

    //    if (result.IsFailure)
    //    {
    //        return HandleFailure(result);
    //    }

    //    return NoContent();
    //}
}
