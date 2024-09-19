using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetPageContentByKeyValueQuery(string key, string rootPage, Language language) : IRequest<PagesContentEntity>;

public class GetPageContentByKeyValueQueryHandler(MoongladeRepository<PagesContentEntity> repo) : IRequestHandler<GetPageContentByKeyValueQuery, PagesContentEntity>
{
  public Task<PagesContentEntity> Handle(GetPageContentByKeyValueQuery request, CancellationToken ct)
  {
    var spec = new PagesContentByKeyValueSpec(request.key, request.rootPage, request.language);
    var entity = repo.SingleOrDefaultAsync(spec, ct);
    return entity;
  }
}
