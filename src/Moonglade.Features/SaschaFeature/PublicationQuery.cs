using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllPublicationsQuery() : IQuery<List<PublicationEntity>>;

public class GetAllPublicationQueryHandler(MoongladeRepository<PublicationEntity> repo) : IQueryHandler<GetAllPublicationsQuery, List<PublicationEntity>>
{
    public Task<List<PublicationEntity>> HandleAsync(GetAllPublicationsQuery request, CancellationToken ct)
    {
        var spec = new PublicationByLanguageSpec();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetPublicationByIdQuery(int id) : IQuery<PublicationEntity>;

public class GetPublicationByIdQueryHandler(MoongladeRepository<PublicationEntity> repo) : IQueryHandler<GetPublicationByIdQuery, PublicationEntity>
{
    public Task<PublicationEntity> HandleAsync(GetPublicationByIdQuery request, CancellationToken ct)
    {
        var spec = new PublicationByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
