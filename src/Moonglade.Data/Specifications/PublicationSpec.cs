using System.Globalization;

using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class PublicationByIdSpec : SingleResultSpecification<PublicationEntity>
{
  public PublicationByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class PublicationByLanguageSpec : Specification<PublicationEntity>
{
  public PublicationByLanguageSpec()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var language = LanguageExtensions.FromLangCodeToLang(langCode);
    if (language == Language.German)
    {
      Query.Where(p => p.Language == Language.German || p.Language == Language.English);
    }
    else
    {
      Query.Where(p => p.Language == language);
    }
    Query.OrderByDescending(p => p.DatePublished);
  }
}
