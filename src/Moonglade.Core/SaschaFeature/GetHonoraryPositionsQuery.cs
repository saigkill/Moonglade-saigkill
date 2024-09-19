using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllHonoraryPositionsQuery() : IRequest<List<HonoraryPositionEntity>>;

public class GetAllHonoraryPositionsQueryHandler(MoongladeRepository<HonoraryPositionEntity> repo) : IRequestHandler<GetAllHonoraryPositionsQuery, List<HonoraryPositionEntity>>
{
  public Task<List<HonoraryPositionEntity>> Handle(GetAllHonoraryPositionsQuery request, CancellationToken ct)
  {
	var spec = new HonoraryPositionAllSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}

public record GetHonoraryPositionsByIdQuery(int id) : IRequest<HonoraryPositionEntity>;

public class GetHonoraryPositionsByIdQueryHandler(MoongladeRepository<HonoraryPositionEntity> repo) : IRequestHandler<GetHonoraryPositionsByIdQuery, HonoraryPositionEntity>
{
  public Task<HonoraryPositionEntity> Handle(GetHonoraryPositionsByIdQuery request, CancellationToken ct)
  {
	var spec = new HonoraryPositionByIdSpec(request.id);
	var entity = repo.SingleOrDefaultAsync(spec, ct);
	return entity;
  }
}

public record GetHonoraryPositionsByLanguageQuery() : IRequest<List<HonoraryPositionEntity>>;

public class GetHonoraryPositionsByLanguageQueryHandler(MoongladeRepository<HonoraryPositionEntity> repo) : IRequestHandler<GetHonoraryPositionsByLanguageQuery, List<HonoraryPositionEntity>>
{
  public Task<List<HonoraryPositionEntity>> Handle(GetHonoraryPositionsByLanguageQuery request, CancellationToken ct)
  {
	var spec = new HonoraryPositionByLanguageSpec();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}
