using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllMembershipQuery() : IRequest<List<MembershipEntity>>;

public class GetAllMembershipQueryHandler(MoongladeRepository<MembershipEntity> repo) : IRequestHandler<GetAllMembershipQuery, List<MembershipEntity>>
{
    public Task<List<MembershipEntity>> Handle(GetAllMembershipQuery request, CancellationToken ct)
    {
        var spec = new MembershipByLanguage();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetMembershipByIdQuery(int id) : IRequest<MembershipEntity>;

public class GetMembershipByIdQueryHandler(MoongladeRepository<MembershipEntity> repo) : IRequestHandler<GetMembershipByIdQuery, MembershipEntity>
{
    public Task<MembershipEntity> Handle(GetMembershipByIdQuery request, CancellationToken ct)
    {
        var spec = new MembershipByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
