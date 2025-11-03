using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllProjectsQuery() : IQuery<List<ProjectEntity>>;

public class GetAllProjectsQueryHandler(MoongladeRepository<ProjectEntity> repo) : IQueryHandler<GetAllProjectsQuery, List<ProjectEntity>>
{
  public Task<List<ProjectEntity>> HandleAsync(GetAllProjectsQuery request, CancellationToken ct)
  {
    var spec = new ProjectByLanguage();
    var list = repo.ListAsync(spec, ct);
    return list;
  }
}

public record GetProjectByIdQuery(int id) : IQuery<ProjectEntity>;

public class GetProjectByIdQueryHandler(MoongladeRepository<ProjectEntity> repo) : IQueryHandler<GetProjectByIdQuery, ProjectEntity>
{
  public Task<ProjectEntity> HandleAsync(GetProjectByIdQuery request, CancellationToken ct)
  {
    var spec = new ProjectByIdSpec(request.id);
    var entity = repo.SingleOrDefaultAsync(spec, ct);
    return entity;
  }
}
