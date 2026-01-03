using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllMandatesQuery() : IQuery<List<MandateEntity>>;

public class GetAllMandatesQueryHandler(MoongladeRepository<MandateEntity> repo) : IQueryHandler<GetAllMandatesQuery, List<MandateEntity>>
{
    public Task<List<MandateEntity>> HandleAsync(GetAllMandatesQuery request, CancellationToken ct)
    {
        var spec = new MandateByLanguageSpec();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetMandatesByIdQuery(int id) : IQuery<MandateEntity>;

public class GetMandatesByIdQueryHandler(MoongladeRepository<MandateEntity> repo) : IQueryHandler<GetMandatesByIdQuery, MandateEntity>
{
    public Task<MandateEntity> HandleAsync(GetMandatesByIdQuery request, CancellationToken ct)
    {
        var spec = new MandateByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
