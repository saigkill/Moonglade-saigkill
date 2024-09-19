using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllCalendarQuery() : IRequest<List<CalendarEntity>>;

public class GetAllCalendarQueryHandler(MoongladeRepository<CalendarEntity> repo) : IRequestHandler<GetAllCalendarQuery, List<CalendarEntity>>
{
  public Task<List<CalendarEntity>> Handle(GetAllCalendarQuery request, CancellationToken ct)
  {
	var spec = new CalendarSpecAll();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}

public record GetCalendarByIdQuery(int id) : IRequest<CalendarEntity>;

public class GetCalendarByIdQueryHandler(MoongladeRepository<CalendarEntity> repo) : IRequestHandler<GetCalendarByIdQuery, CalendarEntity>
{
  public Task<CalendarEntity> Handle(GetCalendarByIdQuery request, CancellationToken ct)
  {
	var spec = new CalendarByIdSpec(request.id);
	var entity = repo.SingleOrDefaultAsync(spec, ct);
	return entity;
  }
}
