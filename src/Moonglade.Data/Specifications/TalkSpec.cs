using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class TalkByIdSpec : SingleResultSpecification<TalkEntity>
{
  public TalkByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class TalkByLanguageSpec : Specification<TalkEntity>
{
  public TalkByLanguageSpec()
  {
    var language = LanguageExtensions.FromLangCodeToLang();
    Query.Where(p => p.Language == language);
  }
}
