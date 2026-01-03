using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllTalkQuery() : IQuery<List<TalkEntity>>;

public class GetAllTalkQueryHandler(MoongladeRepository<TalkEntity> repo) : IQueryHandler<GetAllTalkQuery, List<TalkEntity>>
{
  public Task<List<TalkEntity>> HandleAsync(GetAllTalkQuery request, CancellationToken ct)
  {
    var spec = new TalkByLanguageSpec();
    var list = repo.ListAsync(spec, ct);
    return list;
  }
}

public record GetTalkByIdQuery(int id) : IQuery<TalkEntity>;

public class GetTalkByIdQueryHandler(MoongladeRepository<TalkEntity> repo) : IQueryHandler<GetTalkByIdQuery, TalkEntity>
{
  public Task<TalkEntity> HandleAsync(GetTalkByIdQuery request, CancellationToken ct)
  {
    var spec = new TalkByIdSpec(request.id);
    var entity = repo.SingleOrDefaultAsync(spec, ct);
    return entity;
  }
}
