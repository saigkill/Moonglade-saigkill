using System.Globalization;

using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class VideoByIdSpec : SingleResultSpecification<VideoEntity>
{
  public VideoByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class VideoByLanguageSpec : Specification<VideoEntity>
{
  public VideoByLanguageSpec()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var language = LanguageExtensions.FromLangCodeToLang(langCode);
    Query.Where(p => p.Language == language);
  }
}
