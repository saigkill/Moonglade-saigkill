using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetPageContentByKeyValueQuery(string key, string rootPage, Language language) : IQuery<PagesContentEntity>;

public class GetPageContentByKeyValueQueryHandler(MoongladeRepository<PagesContentEntity> repo) : IQueryHandler<GetPageContentByKeyValueQuery, PagesContentEntity>
{
  public Task<PagesContentEntity> HandleAsync(GetPageContentByKeyValueQuery request, CancellationToken ct)
  {
    var spec = new PagesContentByKeyValueSpec(request.key, request.rootPage, request.language);
    var entity = repo.SingleOrDefaultAsync(spec, ct);
    return entity;
  }
}
