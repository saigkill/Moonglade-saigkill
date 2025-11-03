using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllCalendarQuery() : IQuery<List<CalendarEntity>>;

public class GetAllCalendarQueryHandler(MoongladeRepository<CalendarEntity> repo) : IQueryHandler<GetAllCalendarQuery, List<CalendarEntity>>
{
  public Task<List<CalendarEntity>> HandleAsync(GetAllCalendarQuery request, CancellationToken ct)
  {
	var spec = new CalendarSpecAll();
	var list = repo.ListAsync(spec, ct);
	return list;
  }
}

public record GetCalendarByIdQuery(int id) : IQuery<CalendarEntity>;

public class GetCalendarByIdQueryHandler(MoongladeRepository<CalendarEntity> repo) : IQueryHandler<GetCalendarByIdQuery, CalendarEntity>
{
  public Task<CalendarEntity> HandleAsync(GetCalendarByIdQuery request, CancellationToken ct)
  {
	var spec = new CalendarByIdSpec(request.id);
	var entity = repo.SingleOrDefaultAsync(spec, ct);
	return entity;
  }
}
