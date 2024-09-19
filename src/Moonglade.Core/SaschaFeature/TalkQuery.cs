using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllTalkQuery() : IRequest<List<TalkEntity>>;

public class GetAllTalkQueryHandler(MoongladeRepository<TalkEntity> repo) : IRequestHandler<GetAllTalkQuery, List<TalkEntity>>
{
  public Task<List<TalkEntity>> Handle(GetAllTalkQuery request, CancellationToken ct)
  {
    var spec = new TalkByLanguageSpec();
    var list = repo.ListAsync(spec, ct);
    return list;
  }
}

public record GetTalkByIdQuery(int id) : IRequest<TalkEntity>;

public class GetTalkByIdQueryHandler(MoongladeRepository<TalkEntity> repo) : IRequestHandler<GetTalkByIdQuery, TalkEntity>
{
  public Task<TalkEntity> Handle(GetTalkByIdQuery request, CancellationToken ct)
  {
    var spec = new TalkByIdSpec(request.id);
    var entity = repo.SingleOrDefaultAsync(spec, ct);
    return entity;
  }
}
