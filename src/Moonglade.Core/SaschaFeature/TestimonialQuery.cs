using Moonglade.Data;
using Moonglade.Data.Specifications;

namespace Moonglade.Core.SaschaFeature;

public record GetAllTestimonialsQuery() : IRequest<List<TestimonialEntity>>;

public class GetAllTestimonialsQueryHandler(MoongladeRepository<TestimonialEntity> repo) : IRequestHandler<GetAllTestimonialsQuery, List<TestimonialEntity>>
{
    public Task<List<TestimonialEntity>> Handle(GetAllTestimonialsQuery request, CancellationToken ct)
    {
        var spec = new TestimonialByLanguageSpec();
        var list = repo.ListAsync(spec, ct);
        return list;
    }
}

public record GetTestimonialByIdQuery(int id) : IRequest<TestimonialEntity>;

public class GetTestimonialByIdQueryHandler(MoongladeRepository<TestimonialEntity> repo) : IRequestHandler<GetTestimonialByIdQuery, TestimonialEntity>
{
    public Task<TestimonialEntity> Handle(GetTestimonialByIdQuery request, CancellationToken ct)
    {
        var spec = new TestimonialByIdSpec(request.id);
        var entity = repo.SingleOrDefaultAsync(spec, ct);
        return entity;
    }
}
