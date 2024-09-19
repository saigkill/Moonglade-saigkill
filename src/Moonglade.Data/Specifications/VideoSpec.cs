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
	var language = LanguageExtensions.FromLangCodeToLang();
	Query.Where(p => p.Language == language);
  }
}
