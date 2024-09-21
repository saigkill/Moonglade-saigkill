using System.Globalization;

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
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var language = LanguageExtensions.FromLangCodeToLang(langCode);
    Query.Where(p => p.Language == language).OrderByDescending(p => p.Years);
  }
}
