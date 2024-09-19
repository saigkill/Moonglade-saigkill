using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllMandatesQuery() : IRequest<List<MandateEntity>>;

public class GetAllMandatesQueryHandler(MoongladeRepository<MandateEntity> repo) : IRequestHandler<GetAllMandatesQuery, List<MandateEntity>>
{
    public Task<List<MandateEntity>> Handle(GetAllMandatesQuery request, CancellationToken ct)
    {
        var spec = new MandateByLanguageSpec();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetMandatesByIdQuery(int id) : IRequest<MandateEntity>;

public class GetMandatesByIdQueryHandler(MoongladeRepository<MandateEntity> repo) : IRequestHandler<GetMandatesByIdQuery, MandateEntity>
{
    public Task<MandateEntity> Handle(GetMandatesByIdQuery request, CancellationToken ct)
    {
        var spec = new MandateByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
