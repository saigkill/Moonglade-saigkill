using Moonglade.Data.Entities;

namespace Moonglade.Data.Specifications;

public sealed class MembershipByIdSpec : SingleResultSpecification<MembershipEntity>
{
  public MembershipByIdSpec(int id)
  {
    Query.Where(p => p.Id == id);
  }
}

public sealed class MembershipByLanguage : Specification<MembershipEntity>
{
  public MembershipByLanguage()
  {
    var language = LanguageExtensions.FromLangCodeToLang();
    Query.Where(p => p.Language == language && p.Active);
  }
}
