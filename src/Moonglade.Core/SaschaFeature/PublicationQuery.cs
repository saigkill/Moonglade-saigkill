using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllPublicationsQuery() : IRequest<List<PublicationEntity>>;

public class GetAllPublicationQueryHandler(MoongladeRepository<PublicationEntity> repo) : IRequestHandler<GetAllPublicationsQuery, List<PublicationEntity>>
{
    public Task<List<PublicationEntity>> Handle(GetAllPublicationsQuery request, CancellationToken ct)
    {
        var spec = new PublicationByLanguageSpec();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetPublicationByIdQuery(int id) : IRequest<PublicationEntity>;

public class GetPublicationByIdQueryHandler(MoongladeRepository<PublicationEntity> repo) : IRequestHandler<GetPublicationByIdQuery, PublicationEntity>
{
    public Task<PublicationEntity> Handle(GetPublicationByIdQuery request, CancellationToken ct)
    {
        var spec = new PublicationByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
