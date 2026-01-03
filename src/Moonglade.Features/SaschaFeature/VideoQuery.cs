using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllVideoQuery() : IQuery<List<VideoEntity>>;

public class GetAllVideoQueryHandler(MoongladeRepository<VideoEntity> repo) : IQueryHandler<GetAllVideoQuery, List<VideoEntity>>
{
    public Task<List<VideoEntity>> HandleAsync(GetAllVideoQuery request, CancellationToken ct)
    {
        var spec = new VideoByLanguageSpec();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetVideoByIdQuery(int id) : IQuery<VideoEntity>;

public class GetVideoByIdQueryHandler(MoongladeRepository<VideoEntity> repo) : IQueryHandler<GetVideoByIdQuery, VideoEntity>
{
    public Task<VideoEntity> HandleAsync(GetVideoByIdQuery request, CancellationToken ct)
    {
        var spec = new VideoByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
