using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class TestimonialByIdSpec : SingleResultSpecification<TestimonialEntity>
{
    public TestimonialByIdSpec(int id)
    {
        Query.Where(p => p.Id == id);
    }
}

public sealed class TestimonialByLanguageSpec : Specification<TestimonialEntity>
{
    public TestimonialByLanguageSpec()
    {
        var language = LanguageExtensions.FromLangCodeToLang();
        Query.Where(p => p.Language == language);
    }
}
