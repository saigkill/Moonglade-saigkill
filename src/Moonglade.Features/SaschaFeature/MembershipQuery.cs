using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllMembershipQuery() : IQuery<List<MembershipEntity>>;

public class GetAllMembershipQueryHandler(MoongladeRepository<MembershipEntity> repo) : IQueryHandler<GetAllMembershipQuery, List<MembershipEntity>>
{
    public Task<List<MembershipEntity>> HandleAsync(GetAllMembershipQuery request, CancellationToken ct)
    {
        var spec = new MembershipByLanguage();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetMembershipByIdQuery(int id) : IQuery<MembershipEntity>;

public class GetMembershipByIdQueryHandler(MoongladeRepository<MembershipEntity> repo) : IQueryHandler<GetMembershipByIdQuery, MembershipEntity>
{
    public Task<MembershipEntity> HandleAsync(GetMembershipByIdQuery request, CancellationToken ct)
    {
        var spec = new MembershipByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
