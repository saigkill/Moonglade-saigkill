using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllProjectsQuery() : IRequest<List<ProjectEntity>>;

public class GetAllProjectsQueryHandler(MoongladeRepository<ProjectEntity> repo) : IRequestHandler<GetAllProjectsQuery, List<ProjectEntity>>
{
  public Task<List<ProjectEntity>> Handle(GetAllProjectsQuery request, CancellationToken ct)
  {
    var spec = new ProjectByLanguage();
    var list = repo.ListAsync(spec, ct);
    return list;
  }
}

public record GetProjectByIdQuery(int id) : IRequest<ProjectEntity>;

public class GetProjectByIdQueryHandler(MoongladeRepository<ProjectEntity> repo) : IRequestHandler<GetProjectByIdQuery, ProjectEntity>
{
  public Task<ProjectEntity> Handle(GetProjectByIdQuery request, CancellationToken ct)
  {
    var spec = new ProjectByIdSpec(request.id);
    var entity = repo.SingleOrDefaultAsync(spec, ct);
    return entity;
  }
}
