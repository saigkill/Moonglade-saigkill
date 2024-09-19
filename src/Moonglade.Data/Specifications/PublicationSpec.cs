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
    var language = LanguageExtensions.FromLangCodeToLang();
    Query.Where(p => p.Language == language).OrderByDescending(p => p.DatePublished);
  }
}
