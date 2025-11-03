using LiteBus.Queries.Abstractions;
using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Features.SaschaFeature;

public record GetAllTestimonialsQuery(Audience audience) : IQuery<List<TestimonialEntity>>;

public class GetAllTestimonialsQueryHandler(MoongladeRepository<TestimonialEntity> repo) : IQueryHandler<GetAllTestimonialsQuery, List<TestimonialEntity>>
{
  public Task<List<TestimonialEntity>> HandleAsync(GetAllTestimonialsQuery request, CancellationToken ct)
  {
    var spec = new TestimonialByLanguageSpec(request.audience);
    var list = repo.ListAsync(spec, ct);
    return list;
  }
}

public record GetTestimonialByIdQuery(int id) : IQuery<TestimonialEntity>;

public class GetTestimonialByIdQueryHandler(MoongladeRepository<TestimonialEntity> repo) : IQueryHandler<GetTestimonialByIdQuery, TestimonialEntity>
{
  public Task<TestimonialEntity> HandleAsync(GetTestimonialByIdQuery request, CancellationToken ct)
  {
    var spec = new TestimonialByIdSpec(request.id);
    var entity = repo.SingleOrDefaultAsync(spec, ct);
    return entity;
  }
}
