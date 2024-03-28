using Application.Abstract; 

namespace Application.Members.GetMembersById;

public sealed record GetMemberByIdQuery(Guid MemberId) : IQuery<MemberResponse>;