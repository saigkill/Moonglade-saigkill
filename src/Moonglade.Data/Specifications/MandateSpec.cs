using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class MandateByIdSpec : SingleResultSpecification<MandateEntity>
{
  public MandateByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class MandateByLanguageSpec : Specification<MandateEntity>
{
  public MandateByLanguageSpec()
  {
    var language = LanguageExtensions.FromLangCodeToLang();
    Query.Where(p => p.Language == language).OrderByDescending(p => p.Years);
  }
}
