using System.Globalization;

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
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var language = LanguageExtensions.FromLangCodeToLang(langCode);
    Query.Where(p => p.Language == language);
  }
}
