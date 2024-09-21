using System.Globalization;

using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class ProjectByIdSpec : SingleResultSpecification<ProjectEntity>
{
  public ProjectByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class ProjectByLanguage : Specification<ProjectEntity>
{
  public ProjectByLanguage()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var language = LanguageExtensions.FromLangCodeToLang(langCode);
    Query.Where(p => p.Language == language);
  }
}
