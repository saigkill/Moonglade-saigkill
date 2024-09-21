using System.Globalization;

using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class HonoraryPositionByIdSpec : SingleResultSpecification<HonoraryPositionEntity>
{
  public HonoraryPositionByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class HonoraryPositionAllSpec : Specification<HonoraryPositionEntity>
{
  public HonoraryPositionAllSpec()
  {
    Query.AsNoTracking();
  }
}

public sealed class HonoraryPositionByLanguageSpec : Specification<HonoraryPositionEntity>
{
  public HonoraryPositionByLanguageSpec()
  {
    var langCode = CultureInfo.CurrentUICulture.ToString().ToLower();
    var culture = LanguageExtensions.FromLangCodeToLang(langCode);
    Query.Where(p => p.Language == culture);
  }
}
