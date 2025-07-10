using System.Globalization;

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
  public TestimonialByLanguageSpec(Audience audience)
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var language = LanguageExtensions.FromLangCodeToLang(langCode);
    Query.Where(p => p.Language == language && p.Audience == audience);
  }
}
