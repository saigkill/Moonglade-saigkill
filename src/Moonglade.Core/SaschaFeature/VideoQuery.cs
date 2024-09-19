using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllVideoQuery() : IRequest<List<VideoEntity>>;

public class GetAllVideoQueryHandler(MoongladeRepository<VideoEntity> repo) : IRequestHandler<GetAllVideoQuery, List<VideoEntity>>
{
    public Task<List<VideoEntity>> Handle(GetAllVideoQuery request, CancellationToken ct)
    {
        var spec = new VideoByLanguageSpec();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetVideoByIdQuery(int id) : IRequest<VideoEntity>;

public class GetVideoByIdQueryHandler(MoongladeRepository<VideoEntity> repo) : IRequestHandler<GetVideoByIdQuery, VideoEntity>
{
    public Task<VideoEntity> Handle(GetVideoByIdQuery request, CancellationToken ct)
    {
        var spec = new VideoByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
