using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class CalendarByIdSpec : SingleResultSpecification<CalendarEntity>
{
  public CalendarByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class CalendarSpecAll : Specification<CalendarEntity>
{
  public CalendarSpecAll()
  {
    Query.Where(p => true);
  }
}
