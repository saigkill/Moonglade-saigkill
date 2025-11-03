using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllHonoraryPositionsQuery() : IQuery<List<HonoraryPositionEntity>>;

public class GetAllHonoraryPositionsQueryHandler(MoongladeRepository<HonoraryPositionEntity> repo) : IQueryHandler<GetAllHonoraryPositionsQuery, List<HonoraryPositionEntity>>
{
  public Task<List<HonoraryPositionEntity>> HandleAsync(GetAllHonoraryPositionsQuery request, CancellationToken ct)
  {
	var spec = new HonoraryPositionAllSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}

public record GetHonoraryPositionsByIdQuery(int id) : IQuery<HonoraryPositionEntity>;

public class GetHonoraryPositionsByIdQueryHandler(MoongladeRepository<HonoraryPositionEntity> repo) : IQueryHandler<GetHonoraryPositionsByIdQuery, HonoraryPositionEntity>
{
  public Task<HonoraryPositionEntity> HandleAsync(GetHonoraryPositionsByIdQuery request, CancellationToken ct)
  {
	var spec = new HonoraryPositionByIdSpec(request.id);
	var entity = repo.SingleOrDefaultAsync(spec, ct);
	return entity;
  }
}

public record GetHonoraryPositionsByLanguageQuery() : IQuery<List<HonoraryPositionEntity>>;

public class GetHonoraryPositionsByLanguageQueryHandler(MoongladeRepository<HonoraryPositionEntity> repo) : IQueryHandler<GetHonoraryPositionsByLanguageQuery, List<HonoraryPositionEntity>>
{
  public Task<List<HonoraryPositionEntity>> HandleAsync(GetHonoraryPositionsByLanguageQuery request, CancellationToken ct)
  {
	var spec = new HonoraryPositionByLanguageSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}
