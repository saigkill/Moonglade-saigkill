using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class PagesContentByKeyValueSpec : SingleResultSpecification<PagesContentEntity>
{
  public PagesContentByKeyValueSpec(string key, string rootPage, Language language)
  {
    Query.Where(p => p.Key == key && p.RootPage == rootPage && p.Language == language);
  }
}
